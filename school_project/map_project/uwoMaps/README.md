# **UWO Navigating Maps**
*Created by Taoran Gong, David Alter, Dayton Maurice Alexander Crombie, Minsoo Park, Ryan Cook*
  
## Overview
1. Navigating a university campus can be challenging due to its large size and multiple buildings.
2. Smartphones, GPS, and mapping services like Google Maps help with outdoor navigation but are insufficient for indoor spaces.
3. The application will allow users to search for rooms in buildings, locate points of interest, browse through the available maps, and save personal points of interest.
4. The floor plans primarily serve to identify accessible features but can be useful for locating specific rooms or points of interest.
  
## Requirements
1. Functional Requirements
      1. Browsing Maps
         - The application should allow users to easily browse through maps of all supported buildings.
         - Users should be able to select a building from a list and navigate through its maps.
      2. Searching Maps
         - The application should provide an easy way for users to search for Points of Interest (POIs) in specific buildings.
         - Key points of interest, such as classrooms, restaurants, and washrooms, should be included for the selected buildings.
         - The interface design for performing searches and highlighting the target POI on the map is flexible, such as using drop-down menus or text entry.
      3. Built-in Points of Interest
         - The application should include various types of points of interest (POI) that can be displayed as separate layers on the map.
         - Users should be able to choose which POIs to show or hide by toggling the corresponding layers.
      4. Favourites
         - The application should allow users to mark and unmark built-in points of interest (POI) as favorites.
         - When a user searches for a location, a favorite toggle should be presented for marking purposes.
      5. User Created Points of Interest
         - Users should have the ability to create their own points of interest (POI) in addition to the built-in ones.
         - The application should provide an interface for users to designate a point on the map and provide a name and description for the created POI.
      6. Editing Tool
      7. Housekeeping
      8. Multiuser System
      9. Optinal features (Metadata)
            
2. Non-functional Requirements
      1. Java
      2. Swing
            - Implement the GUI using the Spring framework
      3. JSON
            - To store the metadata is JSON
      4. Javadoc
            - To manage comment
            
3. How to run
      1. Dependencies
         - https://jar-download.com/artifacts/org.apache.httpcomponents/httpclient
         - https://jar-download.com/artifacts/com.github.cliftonlabs/json-simple/2.3.0/source-code
         - https://jar-download.com/artifacts/org.json
      2. Simply run main.java
