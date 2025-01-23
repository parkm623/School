import socket
import signal
import sys
from urllib.parse import urlparse

# Saved information on the discovery.

port = 8888



# The discovery's socket.

discovery_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

# Bind the discovery's socket.

discovery_socket.bind(('', port))

# List of servers currently registered.

server_list = []

# Catch the Ctrl-c

def signal_handler(sig, frame):
    print('Interrupt received, shutting down ...')
    sys.exit(0)

# Register the server name and address(port) to list

def register(name, address):
    registration = (name, address)
    if server_list:
        for reg in server_list:
            if reg[0] == name:
                return False
            elif reg[1] == address:
                return False
            else:
                server_list.append(registration)
                return True
    else:
        server_list.append(registration)
        return True

# Deregister the server name and address(port) to list

def deregister(name):
    for reg in server_list:
        if reg[0] == name:
            server_list.remove(reg)
            return True
    return False

# Find the address(port) from list by the name

def lookup(name):
    for reg in server_list:
        if reg[0] == name:
            address = reg[1]
            print(address)
            return address
    return None

# Managing command from server and client

def process_message(message, addr):
    words = message.split()


    if words[0] == "REGISTER":
        if len(words) == 3:
            address = words[1]
            name = words[2]
            result = register(name,address)
            if result:
                msg = "OK, register is successfully worked"
                return msg
            else:
                msg = "NOT OK, it is already existed, please try again."
                return msg
        else:
            return "Invalid command"

    elif words[0] == "DEREGISTER":
        if len(words) == 2:
            name = words[1]
            result = deregister(name)
            if result:
                msg = "OK, your deletion is successful"
                return msg
            else:
                msg = "NOT OK, the provided server name is not existed."
                return msg
        else:
            return "Invalid command"

    elif words[0] == "LOOKUP":
        if len(words) == 2:
            name = words[1]
            result = lookup(name)
            if result:
                msg = str(result)
                return msg
            else:
                msg = "NOT OK, the provided server name is not existed."
                return msg
        else:
            return "Invalid command"

    else:
        return "Invalid command"

def main():
    signal.signal(signal.SIGINT, signal_handler)

    while True:

        # Receive a packet from a client and process it.

        message, addr = discovery_socket.recvfrom(1024)

        # Process the message and retrieve a response.

        response = process_message(message.decode(), addr)

        # Send the response message back to the client.

        discovery_socket.sendto(response.encode(),addr)


if __name__ == '__main__':
    main()
