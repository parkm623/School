from socket import *
from urllib.parse import urlparse
import sys
import signal

def handler(signum, frame): #Ctrl+C handler
    userMessage = 'exit'
    if inventory:
        for i in range(len(inventory)):
            dropM = 'drop ' + inventory[i] #drom the all itmes of inventory to the room
            userSock.sendto(dropM.encode(), serverAddr)

    userSock.sendto(userMessage.encode(), serverAddr) #send exit message to server
    userSock.close() #close user socket and exit
    exit()

inventory = [] #declare empty inventory
userName = sys.argv[1] #get user name from system input
serverName = sys.argv[2] #get server name from system input
serverP = urlparse(serverName) #convert url to get hostname and port
serverAddr = (serverP.hostname, serverP.port)

try:
    userSock = socket(AF_INET,SOCK_DGRAM) #create user socket
    userSock.sendto(userName.encode(), serverAddr) # send user name to server
except Exception as e: #check invalid server address, if yes quit
    print('Invalid address, please input valid address')
    exit()

reply, serverAddr = userSock.recvfrom(2048) #get reply from server which is description of room
reply = reply.decode()
print(reply)

while True:

    signal.signal(signal.SIGINT, handler) #check Ctrl+C
    inventoryPrint ='' #reset print of inventory
    userMessage = input().lower() #store lower case of user input

    if userMessage == 'inventory': #if user input inventory, show list of items of inventory
        for i in range(len(inventory)):
            inventoryPrint += ' ' + inventory[i] + '\n'
        print('You are holding:\n'+ inventoryPrint)
    elif 'take' in userMessage: #if user input take, then send input message to server
        userSock.sendto(userMessage.encode(), serverAddr)
        reply, serverAddr = userSock.recvfrom(2048)
        reply = reply.decode()
        if 'taken' in reply: #if reply has 'taken' which means vaild item can be stored in inventory
            reply = reply.split() #split sentence to two part and store item to inventory
            inventory.append(reply[0])
            print(reply[0] +' ' + reply[1])
        else:
            print(reply) #get error message from server
    elif 'drop' in userMessage:
        if inventory:
            for i in range(len(inventory)): #check list of item from inventory
                if inventory[i] in userMessage: #if there is correct item from inventory
                    userSock.sendto(userMessage.encode(), serverAddr)
                    del inventory[i] #send 'drop' + 'item' to server and delete that item from inventory
                    break
                elif i == len(inventory) - 1: #if there are no matched item on inventory
                    userMessage = userMessage.split()
                    print('You are not holding ' + userMessage[1])
        else: #if inventory is empty
            print('Your inventory is empty')
    elif userMessage == 'exit':
        if inventory:
            for i in range(len(inventory)): #drop the every items from inventory
                dropM = 'drop ' + inventory[i]
                userSock.sendto(dropM.encode(), serverAddr)

        userSock.sendto(userMessage.encode(), serverAddr) #quit server socket and file as well
        userSock.close() #close user socket and exit the file
        exit()
    else: #if user input invalid message, return error message from server
        userSock.sendto(userMessage.encode(), serverAddr)
        reply, serverAddr = userSock.recvfrom(2048)
        reply = reply.decode()
        print(reply)





