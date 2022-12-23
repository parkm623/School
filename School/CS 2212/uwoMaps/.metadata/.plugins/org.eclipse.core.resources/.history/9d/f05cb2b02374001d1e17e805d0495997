package uwoMaps;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

/**
 * @author Dayton Crombie, dcrombie@uwo.ca
 * @version 1.1
 * This class will be used to edit users custom POIs and write them to JSON files
 */

public class UserPOI extends POI{
	
	/*
	 * Allows the user the ability to set a description to their custom
	 * Point of Interest  
	 */
	private String description;
	
	/*
	 * X and Y positions that the Point of interest is located on
	 */
	public float xCoordinate;
	public float yCoordinate;

	/**
	 * Constructor that initializes instance variables for parent class
	 * 
	 * Variables for POI parent class:
	 * @param POIname - name of the point of interest
	 * @param floor - floor that the POI is associated with
	 * @param vis - whether or not the POI is visible on the map
	 * 
	 */
	public UserPOI(String POIname, String buildingName, Floor floor, Boolean vis) {
		super(POIname, buildingName, floor, vis);
	}
	
	/**
	 * Return description of user POI
	 * @return
	 */
	public String getDescription() {
		return description;
	}

	/**
	 * Set description of user POI
	 * @param description
	 */
	public void setDescription(String description) {
		this.description = description;
	}
	
	/**
	 * Add a user created POI to the user data JSON file
	 * @param POIName
	 * @param buildingName
	 * @param id
	 */
	public static void addUserPOI(String POIName, String buildingName, String id) {
		JSONParser jsonParser = new JSONParser();
		try (FileReader reader = new FileReader("userData.json")) {
			Object obj = jsonParser.parse(reader);
			JSONArray userList = (JSONArray) obj;
			userList.forEach(user -> {
				JSONObject tempUser = (JSONObject) user;
				JSONObject userObject = (JSONObject) tempUser.get("user");
				if (userObject.get("username").equals(id)) {
					JSONObject userPOIsList = (JSONObject) userObject.get("userPOIs");
					if (buildingName.toLowerCase().contains("alumni")) {
						JSONArray alumniUserPOIs = (JSONArray) userPOIsList.get("alumni");
						alumniUserPOIs.add(POIName);
					}
					else if (buildingName.toLowerCase().contains("middlesex")) {
						JSONArray middlesexUserPOIs = (JSONArray) userPOIsList.get("middlesex");
						middlesexUserPOIs.add(POIName);
					}
					else if (buildingName.toLowerCase().contains("health")) {
						JSONArray healthSciUserPOIs = (JSONArray) userPOIsList.get("healthsci");
						healthSciUserPOIs.add(POIName);
					}
				}
			});
			FileWriter file = new FileWriter("userData.json");
			file.write(userList.toJSONString());
			file.flush();
			file.close();
		}
		catch (FileNotFoundException e) {
            e.printStackTrace();
        }
		catch (IOException e) {
            e.printStackTrace();
        }
		catch (ParseException e) {
            e.printStackTrace();
        }
	}
	
	/**
	 * Remove a user created POI from the user data JSON file
	 * @param POIName
	 * @param buildingName
	 * @param id
	 */
	public static void removeUserPOI(String POIName, String buildingName, String id) {
		JSONParser jsonParser = new JSONParser();
		try (FileReader reader = new FileReader("userData.json")) {
			Object obj = jsonParser.parse(reader);
			JSONArray userList = (JSONArray) obj;
			userList.forEach(user -> {
				JSONObject tempUser = (JSONObject) user;
				JSONObject userObject = (JSONObject) tempUser.get("user");
				if (userObject.get("username").equals(id)) {
					JSONObject userPOIsList = (JSONObject) userObject.get("userPOIs");
					if (buildingName.toLowerCase().contains("alumni")) {
						JSONArray alumniUserPOIs = (JSONArray) userPOIsList.get("alumni");
						for (int i = 0; i < alumniUserPOIs.size(); i++) {
							if (alumniUserPOIs.get(i).equals(POIName)) {
								alumniUserPOIs.remove(i);
							}
						}
					}
					else if (buildingName.toLowerCase().contains("middlesex")) {
						JSONArray middlesexUserPOIs = (JSONArray) userPOIsList.get("middlesex");
						for (int i = 0; i < middlesexUserPOIs.size(); i++) {
							if (middlesexUserPOIs.get(i).equals(POIName)) {
								middlesexUserPOIs.remove(i);
							}
						}
					}
					else if (buildingName.toLowerCase().contains("health")) {
						JSONArray healthSciUserPOIs = (JSONArray) userPOIsList.get("healthsci");
						for (int i = 0; i < healthSciUserPOIs.size(); i++) {
							if (healthSciUserPOIs.get(i).equals(POIName)) {
								healthSciUserPOIs.remove(i);
							}
						}
					}
				}
			});
			FileWriter file = new FileWriter("userData.json");
			file.write(userList.toJSONString());
			file.flush();
			file.close();
		}
		catch (FileNotFoundException e) {
            e.printStackTrace();
        }
		catch (IOException e) {
            e.printStackTrace();
        }
		catch (ParseException e) {
            e.printStackTrace();
        }
	}
}