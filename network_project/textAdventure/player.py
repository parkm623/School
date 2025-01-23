import socket
import signal
import sys
import argparse
from urllib.parse import urlparse
import selectors

# Selector for helping us select incoming data from the server and messages typed in by the user.

sel = selectors.DefaultSelector()

# Socket for sending messages.

client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

# Server address.

server = ('', '')

# discovery address.

discovery = ('', 8888)

# Room name for lookup.

room_name = ''

# User name for tagging sent messages.

name = ''

# Inventory of items.

inventory = []

# Directions that are possible.

connections = { 
    "north" : "",
    "south" : "",
    "east" : "",
    "west" : "",
    "up" : "",
    "down" : ""
    }

# Constant variable of time to set 5 sec.

CONST_TIME = 5

# Signal handler for graceful exiting.  Let the server know when we're gone.

def signal_handler(sig, frame):
    print('Interrupt received, shutting down ...')
    message='exit'
    client_socket.sendto(message.encode(),server)
    for item in inventory:
        message = f'drop {item}'
        client_socket.sendto(message.encode(), server)
    sys.exit(0)

# Simple function for setting up a prompt for the user.

def do_prompt(skip_line=False):
    if (skip_line):
        print("")
    print("> ", end='', flush=True)

# Function to join a room.

def join_room():

    message = f'join {name}'
 #   client_socket.setsockopt(socket.SOL_SOCKET, socket.SO_BROADCAST, 1)
    client_socket.settimeout(CONST_TIME)
    client_socket.sendto(message.encode(), server)
    try:
        response, addr = client_socket.recvfrom(1024)
    except OSError as msg:
        print('Something bad happened')
        sys.exit()
    print(response.decode())

# Function to handle commands from the user, checking them over and sending to the server as needed.

def process_command(command):

    global server

    # Parse command.

    words = command.split()

    # Check if we are dropping something.  Only let server know if it is in our inventory.

    if (words[0] == 'drop'):
        if (len(words) != 2):
            print("Invalid command")
            return
        elif (words[1] not in inventory):
            print(f'You are not holding {words[1]}')
            return

    # Send command to server, if it isn't a local only one.

    if (command != 'inventory'):
        message = f'{command}'
        client_socket.settimeout(CONST_TIME)
        client_socket.sendto(message.encode(), server)

    # Check for particular commands of interest from the user.

    # If we exit, we have to drop everything in our inventory into the room.

    if (command == 'exit'):
        for item in inventory:
            message = f'drop {item}'
            client_socket.sendto(message.encode(), server)
        sys.exit(0)

    # If we look, we will be getting the room description to display.

    elif (command == 'look'):
        try:
            response, addr = client_socket.recvfrom(1024)
        except OSError as msg:
            print('Error, please try to reconnect.')
            sys.exit()
        print(response.decode())


    # If we inventory, we never really reached out to the room, so we just display what we have.

    elif (command == 'inventory'):
        print("You are holding:")
        if (len(inventory) == 0):
            print('  No items')
        else:
            for item in inventory:
                print(f'  {item}')

    # If we take an item, we let the server know and put it in our inventory, assuming we could take it.

    elif (words[0] == 'take'):
        # response, addr = client_socket.recvfrom(1024)
        # print(response.decode())
        try:
            response, addr = client_socket.recvfrom(1024)
        except OSError as msg:
            print('Error, please try to reconnect.')
            sys.exit()
        print(response.decode())
        words = response.decode().split()
        if ((len(words) == 2) and (words[1] == 'taken')):
            inventory.append(words[0])

    # If we drop an item, we remove it from our inventory and give it back to the room.

    elif (words[0] == 'drop'):
        # response, addr = client_socket.recvfrom(1024)
        # print(response.decode())
        try:
            response, addr = client_socket.recvfrom(1024)
        except OSError as msg:
            print('Error, please try to reconnect.')
            sys.exit()
        print(response.decode())
        inventory.remove(words[1])

    # If we're wanting to go in a direction, we check with the room and it will tell us if it's a valid
    # direction.  We can then join the new room as we know we've been dropped already from the other one.

    elif (words[0] in connections):
        # response, addr = client_socket.recvfrom(1024)
        try:
            response, addr = client_socket.recvfrom(1024)
            response = response.decode()
            if len(response) > 6:
                print(response)
            else:
                msg = lookup(response)
                if "NOT" in msg:
                    print(msg)
                    sys.exit(1)
                else:
                    server = ('', int(msg))
                    join_room()
        except OSError as msg:
            print('Error, please try to reconnect.')
            sys.exit()



    # The player wants to say something ... print the response.

    elif (words[0] == 'say'):
        # response, addr = client_socket.recvfrom(1024)
        # print(response.decode())
        try:
            response, addr = client_socket.recvfrom(1024)
        except OSError as msg:
            print('Error, please try to reconnect.')
            sys.exit()
        print(response.decode())

    # Otherwise, it's an invalid command so we report it.

    else:
        try:
            response, addr = client_socket.recvfrom(1024)
        except OSError as msg:
            print('Error, please try to reconnect.')
            sys.exit()
        print(response.decode())

# Function to handle incoming messages from room.  Also look for disconnect messages to shutdown.

def handle_message_from_server(sock, mask):
    response, addr = client_socket.recvfrom(1024)
    words=response.decode().split(' ')
    print()
    if len(words) == 1 and words[0] == 'disconnect':
        print('Disconnected from server ... exiting!')
        sys.exit(0)
    else:
        print(response.decode())
        do_prompt()

# Function to handle incoming messages from user.

def handle_keyboard_input(file, mask):
    line=sys.stdin.readline()[:-1]
    if line:
        process_command(line)
        do_prompt()
    else:
        print("Error, please input something")
        do_prompt()


# Function get address of server.
def lookup(roomName):
    msg = "LOOKUP" + ' ' + roomName
    client_socket.settimeout(CONST_TIME)
    client_socket.sendto(msg.encode(), discovery)
    try:
        message, addr = client_socket.recvfrom(1024)
    except OSError as msg:
        print('Error, please try to reconnect.')
        sys.exit()
    message = message.decode()
    return message
# Our main function.

def main():

    global name
    global client_socket
    global server
    global room_name

    # Register our signal handler for shutting down.

    signal.signal(signal.SIGINT, signal_handler)

    # Check command line arguments to retrieve a URL.

    parser = argparse.ArgumentParser()
    parser.add_argument("name", help="name for the player in the game")
    parser.add_argument("roomName", help="name for the room in the game")

    args = parser.parse_args()
    name = args.name
    room_name = args.roomName

    #Find the port from the discovery sever with entered name

    msg = lookup(room_name)

    #Dealing with error, if discovery server return back NOT OK, program is terminated

    if "NOT" in msg:
        print(msg)
        sys.exit(1)
    else:
        server = ('',int(msg))
        print("OK, now ur connecting to port " +str(msg))

    # Send message to enter the room.

    join_room()

    # Set up our selector.

    #client_socket.setblocking(False)
    sel.register(client_socket, selectors.EVENT_READ, handle_message_from_server)
    sel.register(sys.stdin, selectors.EVENT_READ, handle_keyboard_input)
    
    # Prompt the user before beginning.

    do_prompt()

    # Now do the selection.

    while(True):
        events = sel.select()
        for key, mask in events:
            callback = key.data
            callback(key.fileobj, mask)    


if __name__ == '__main__':
    main()
