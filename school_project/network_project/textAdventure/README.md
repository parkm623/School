# **Text adventure project**
*Created by Minsoo Park*

## Overview
1. Write a client-server text adventure game.
2. A networked applications, software supporting a simple protocol

## Requirements
1. Network Layering
    - The game client and server will establish communication using UDP (User Datagram Protocol).
    - A server runs room section and a client runs user information.
2. Adding Timeouts
    - Implement error handling in case the client does not receive communication from the server within a reasonable timeframe.
    - Report an error and exit the client program if it does not hear from the server after a specified duration.
3. Discovery Service
    - When a room server starts, it registers its name and address with the discovery service.
    - Player clients or other room servers can lookup the server's address by querying the discovery service.
4. Multi Access
    - Room descriptions received by players from the room server will now include a list of other players present in the room.
    - Players will not see themselves listed in the room description; only other players in the room will be visible.
5. Supporting more than one game room
    - Players can navigate between rooms using directional commands (north, south, east, west, up, and down).
    - Room servers require optional parameters to specify the connections to neighboring rooms in the corresponding directions.



## Using tools
1. Socket API in Python.
2. Any command line interface.
## How to run

There are three python file, discovery.py, player.py, and room.py 
Following the order, it should be start from discovery file.
You can have more than one rooms and server, but the room always be connected.

*Running one servers with one player*
1. `python3 discovery.py`
2. `python3 player.py player_name room1_name`
3. `python3 room.py -direction room1_name "Room expression."  items`

*Running two servers with two player*
1. `python3 discovery.py`
2. `python3 player.py player1_name room1_name`
3. `python3 player.py player2_name room1_name`
4. `python3 room.py -direction room1_name room2_name "Room expression."  items`
5. `python3 room.py -direction room2_name room1_name "Room expression."  items`





