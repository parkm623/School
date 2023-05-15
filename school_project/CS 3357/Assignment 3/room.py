import socket
import signal
import sys
import argparse
import select
from urllib.parse import urlparse

# Saved information on the room.

name = ''
description = ''
items = []
connections = []
client = ''
next_server = ('', '')
direction = ''

# List of clients currently in the room.

client_list = []


# Signal handler for graceful exiting.
# Send disconnection msg to clients
def signal_handler(sig, frame):
    print('Interrupt received, shutting down ...')
    for user in client_list:
        message = 'Disconnected from server ... exiting!'
        connections[0].sendto(message.encode(), user[1])
    sys.exit(0)


# Search the client list for a particular player.

def client_search(player):
    for reg in client_list:
        if reg[0] == player:
            return reg[1]
    return None


# Search the client list for a particular player by their address.

def client_search_by_address(address):
    for reg in client_list:
        if reg[1] == address:
            return reg[0]
    return None


# Add a player to the client list.

def client_add(player, address):
    registration = (player, address)
    client_list.append(registration)


# Remove a client when disconnected.

def client_remove(player):
    for reg in client_list:
        if reg[0] == player:
            client_list.remove(reg)
            break


# Summarize the room into text.
# Show the player who are in same room, but not the user itsefl
def summarize_room():
    global name
    global description
    global items
    global client_list
    global client

    # Pack description into a string and return it.
    summary = name + '\n\n' + description + '\n\n'
    if len(items) == 0 and len(client_list) == 0:
        summary += "The room is empty.\n"
    elif len(items) == 1:
        summary += "In this room, there is:\n"
        summary += f'  {items[0]}\n'
        if len(client_list) > 1:
            for user in client_list:
                if user[0] != client:
                    summary += f'  {user[0]}\n'
    else:
        summary += "In this room, there are:\n"
        for item in items:
            summary += f'  {item}\n'

        if len(client_list) > 1:
            for user in client_list:
                if user[0] != client:
                    summary += f'  {user[0]}\n'

    return summary


def print_room_summary():
    print(summarize_room()[:-1])


# Process incoming message.

def process_message(message, addr):
    # Parse the message.
    global client
    global direction
    words = message.split()

    # If player is joining the server, add them to the list of players.
    # Send msg to current user, if new user join the room
    if (words[0] == 'join'):
        if (len(words) == 2):
            client_add(words[1], addr)
            print(f'User {words[1]} joined from address {addr}')
            if len(client_list) > 1:
                client = client_search_by_address(addr)
                send_join(client)
            return summarize_room()[:-1]
        else:
            return "Invalid command"

    # If player is leaving the server. remove them from the list of players.
    # Send msg to current user, if other user left the game
    elif (message == 'exit'):
        client = client_search_by_address(addr)
        print(client + ' left the game')
        client_remove(client)
        send_left_game(client)
        return 'Goodbye'

    # If player looks around, give them the room summary.
    elif (message == 'look'):
        return summarize_room()[:-1]

    # If player takes an item, make sure it is here and give it to the player.
    elif (words[0] == 'take'):
        if (len(words) == 2):
            if (words[1] in items):
                items.remove(words[1])
                return f'{words[1]} taken'
            else:
                return f'{words[1]} cannot be taken in this room'
        else:
            return "Invalid command"

    # If player drops an item, put in in the list of things here.
    elif (words[0] == 'drop'):
        if (len(words) == 2):
            items.append(words[1])
            return f'{words[1]} dropped'
        else:
            return "Invalid command"

    #Check the users' input direction option and if correct give specific other server address
    #Send msg to current user, if other user move the room
    elif (len(words) == 1 and (words[0] == direction)):
        client = client_search_by_address(addr)
        print(client + ' left the room')
        client_remove(client)
        send_left(client)
        return next_server[0] + ' ' +str(next_server[1])

    #echo the users' input to other players
    elif (words[0] == 'say'):
        client = client_search_by_address(addr)
        client_message = ''
        if (len(words) > 1):
            for word in words[1:]:
                client_message = client_message + ' ' + str(word)
            send_msg(client, client_message)
            return 'You said "' + client_message + '".'
        else:
            return 'What did you want to say?'

    # Otherwise, the command is bad.

    else:
        return "Invalid command"

    #Send msg to other user
def send_msg(client_name,msg):
    for user in client_list:
        if user[0] != client_name:
            message = client_name + ' said "' + msg + '".'
            connections[0].sendto(message.encode(), user[1])

    # Send join msg to other user
def send_join(client_name):
    for user in client_list:
        if user[0] != client_name:
            message = client_name + ' entered the room.'
            connections[0].sendto(message.encode(), user[1])

    # Send left msg to other user
def send_left(client_name):
    for user in client_list:
        if user[0] != client_name:
            message = client_name + ' left the room, heading ' + direction
            connections[0].sendto(message.encode(), user[1])

    # Send left game msg to other user
def send_left_game(client_name):
    for user in client_list:
        if user[0] != client_name:
            message = client_name + ' left the game.'
            connections[0].sendto(message.encode(), user[1])

    # Check the provided direction option and configure to string
def direction_finder(args):
    global next_server
    global direction
    if args.n != None:
        next_server = args.n
        direction = 'north'
    elif args.s !=None:
        next_server = args.s
        direction = 'south'
    elif args.e !=None:
        next_server = args.e
        direction = 'east'
    elif args.w !=None:
        next_server = args.w
        direction = 'west'
    elif args.u !=None:
        next_server = args.u
        direction = 'up'
    elif args.d !=None:
        next_server = args.d
        direction = 'down'
    else:
        print('Invalid direction, Please input correct direction')
        sys.exit(1)

# Our main function.
def main():
    global name
    global description
    global items
    global connections
    global next_server
    global direction

    # Register our signal handler for shutting down.

    signal.signal(signal.SIGINT, signal_handler)

    # Check command line arguments for room settings.

    parser = argparse.ArgumentParser()

    parser.add_argument("-n")
    parser.add_argument("-s")
    parser.add_argument("-e")
    parser.add_argument("-w")
    parser.add_argument("-u")
    parser.add_argument("-d")
    parser.add_argument("port", type=int, help="port number to list on")
    parser.add_argument("name", help="name of the room")
    parser.add_argument("description", help="description of the room")
    parser.add_argument("item", nargs='*', help="items found in the room by default")


    args = parser.parse_args()
    direction_finder(args)
    port = args.port
    name = args.name
    description = args.description
    items = args.item

    try:
        server_address = urlparse(next_server)
        if ((server_address.scheme != 'room') or (server_address.port == None) or (server_address.hostname == None)):
            raise ValueError
        next_host = server_address.hostname
        next_port = server_address.port
        next_server = (next_host, next_port)
    except ValueError:
        print('Error:  Invalid server.  Enter a URL of the form:  room://host:port')
        sys.exit(1)

    # Report initial room state.
    print('Room Starting Description:\n')
    print_room_summary()

    # Create the socket.  We will ask this to work on any interface and to use
    # the port given at the command line.  We'll print this out for clients to use.

    room_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    room_socket.bind(('', port))
    print('\nRoom will wait for players at port: ' + str(room_socket.getsockname()[1]))
    connections = [room_socket]

    # Loop forever waiting for messages from clients.
    # Use select to accept multiple user
    while True:
        readables, writeables, excpetions = select.select(connections, [], [])
        for sock in readables:
            msg, addr = sock.recvfrom(1024)
            response = process_message(msg.decode(), addr)
            sock.sendto(response.encode(), addr)


if __name__ == '__main__':
    main()

