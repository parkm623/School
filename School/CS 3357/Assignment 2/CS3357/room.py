from socket import *
import sys
import signal

def handler(signum, frame): #Crtl+C handler
    hostSock.close()
    exit() #exit the room.py, but this time, doesn't need to inform to player

items = [] #declare items list
itemPrint =''
host = '' #declare host IP as empty which means local IP
online = [] #create list of contain online user

for i in range(len(sys.argv)): #consider system input value by part of part
    if   i == 1:
        port = int(sys.argv[i]) #second value is port number
    elif i == 2:
        roomName = sys.argv[i] #third value is a room name
    elif i == 3:
        description = sys.argv[i] #fourth value is description of room
    elif i > 3:
        items.append(sys.argv[i]) #from fifth, check the items and put on items list

for i in range(len(items)): #set output format of items list
    itemPrint += ' ' + items[i] +'\n'

address = (host,port) #set address at localhost with provided port

hostSock = socket(AF_INET,SOCK_DGRAM) #create host socket
hostSock.bind(address) #bind address on host socket

#print information of the room
print('Room starting Description:\n')
print(roomName, end='\n\n')
print(description, end='\n\n')
print('In this room, there are:')
print(itemPrint)

print('\nRoom will wait for players at port: ',port)


userName, cliAddr = hostSock.recvfrom(2048) #recieve player's information
userName = userName.decode()
print('User',userName,'joined from address', cliAddr)

online.append(userName) #store user data on Online list

hostReply = roomName + '\n\n' + description +'\n\n' +'In this room, there are:'+'\n'+itemPrint
hostSock.sendto(hostReply.encode(), cliAddr) #reply to user about room description


while True: #loop until user exit or server catch Ctrl+C
    itemPrint = '' #reset item print
    hostReply = '' #rest host's reply

    signal.signal(signal.SIGINT, handler) #cacth the Ctrl+C

    cliMessage, cliAddr = hostSock.recvfrom(2048) #receive socket from player and decode
    cliMessage = cliMessage.decode()

    for i in range(len(items)):
        itemPrint += ' ' + items[i] + '\n'

    if cliMessage == 'join': #if player enter join, show the room description this time
        hostReply = roomName + '\n\n' + description + '\n\n' + 'In this room, there are:' + '\n' + itemPrint
        hostSock.sendto(hostReply.encode(), cliAddr)
    elif cliMessage == 'look': #if user enter look, show the items list of room
        if not items: #if there are no items in the room
            hostReply = roomName + '\n\n' + description + '\n\n' + 'In this room, there is:' + '\n' + 'Nothing. Room is empty'
            hostSock.sendto(hostReply.encode(), cliAddr)
        elif len(items) == 1: #if there is only one item existed in the room
            hostReply = roomName + '\n\n' + description + '\n\n' + 'In this room, there is:' + '\n' + itemPrint
            hostSock.sendto(hostReply.encode(), cliAddr)
        else: #if there are more than one item are
            hostReply = roomName + '\n\n' + description + '\n\n' + 'In this room, there are:' + '\n' + itemPrint
            hostSock.sendto(hostReply.encode(), cliAddr)

    elif 'take' in cliMessage:
        if items:
            for i in range(len(items)): #search the item form items list
                if items[i] in cliMessage: #if item in the list(room)
                    hostReply = items[i] + ' taken' #return item name and 'taken'
                    hostSock.sendto(hostReply.encode(), cliAddr)
                    del items[i] #delete item from items list
                    break
                elif i == len(items) -1: #if item is not existed on the room
                    hostReply = 'That Item is not existed on room'
                    hostSock.sendto(hostReply.encode(), cliAddr)

        else: #if the room doesn't have any item
            hostReply = 'There are no items on room'
            hostSock.sendto(hostReply.encode(), cliAddr)
    elif 'drop' in cliMessage:
        cliMessage = cliMessage.split() #divide a sentence and get item name from list
        items.append(cliMessage[1]) #put item on room's items list
    elif cliMessage == 'exit': #if player input exit, close the server
        print('Shutting down...')
        hostSock.close()
        exit()
    else: #if player input invalid command, return error cliMessage
        hostReply = 'Invalid command, please try again'
        hostSock.sendto(hostReply.encode(), cliAddr)


