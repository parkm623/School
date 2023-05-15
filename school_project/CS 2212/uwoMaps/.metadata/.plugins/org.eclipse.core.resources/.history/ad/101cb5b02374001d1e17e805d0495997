package uwoMaps;

import java.util.HashMap;
import java.util.LinkedList;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
 
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

/**
 * @author Dayton Crombie, dcrombie@uwo.ca
 * @version 1.1
 * This class will be used to read user data from JSON files
 */

public class UserData {
	
	/**
	 * This class will use a hashmap implementation to store usernames
	 * and passwords, anytime the constructor is called, a new pair gets
	 * pushed onto the hashmap. 
	 */
	private static HashMap<String, String> loginInfo = new HashMap<String,String>();
	
	private static HashMap<String, Favourite> favInfo = new HashMap<String, Favourite>();
	
	private static HashMap<String, LinkedList<UserPOI>> customPOIInfo = new HashMap<String, LinkedList<UserPOI>>();
	
	public static HashMap<String, Boolean> canEdit = new HashMap<String, Boolean>();
	

	UserData(String id, String password){
		loginInfo.put(id, password);
	}
	
	protected static HashMap<String, String> getLoginInfo() {
		buildLoginHashmap("userData.json");
		return loginInfo;
	}
	
	public static Favourite getFavs(String id) {
		buildFavouritesHashmap("userData.json");
		return favInfo.get(id);
	}
	
	public static LinkedList<UserPOI> getCustomPOIs(String id) {
		buildUserPOIsHashmap("userData.json");
		return customPOIInfo.get(id);
	}
	
	public static Boolean canUserEdit(String id) {
		buildCanEditHashmap("userData.json");
		return canEdit.get(id);
	}
	
	/**
	 * Reads each users login information from JSON file and stores in hash map
	 * @param fileName
	 */
	private static void buildLoginHashmap(String fileName) {
		JSONParser jsonParser = new JSONParser();
		try (FileReader reader = new FileReader(fileName)) {
			Object obj = jsonParser.parse(reader);
			JSONArray userList = (JSONArray) obj;
			userList.forEach(user -> addLoginToHashmap((JSONObject) user));
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
	 * Helper method for building login hash map that handles a single users information in a JSON file
	 * @param user
	 */
	private static void addLoginToHashmap(JSONObject user) {
		JSONObject userObject = (JSONObject) user.get("user");
		loginInfo.put((String) userObject.get("username"), (String) userObject.get("password"));	
	}
	
	/**
	 * Reads each users permission to edit from a JSON file and adds it to hash map
	 * @param fileName
	 */
	private static void buildCanEditHashmap(String fileName) {
		JSONParser jsonParser = new JSONParser();
		try (FileReader reader = new FileReader(fileName)) {
			Object obj = jsonParser.parse(reader);
			JSONArray userList = (JSONArray) obj;
			userList.forEach(user -> addCanEditToHashmap((JSONObject) user));
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
	 * Helper method to build edit permissions hash map that handles a single user data from JSON file
	 * @param user
	 */
	private static void addCanEditToHashmap(JSONObject user) {
		JSONObject userObject = (JSONObject) user.get("user");
		String edit = (String) userObject.get("canEdit");
		if (edit.equals("0")) {
			canEdit.put((String) userObject.get("username"), false);
		}
		else if (edit.equals("1")) {
			canEdit.put((String) userObject.get("username"), true);
		}
	}
	
	/**
	 * Reads each users favourites from JSON file and adds them to hash map
	 * @param fileName
	 */
	private static void buildFavouritesHashmap(String fileName) {
		JSONParser jsonParser = new JSONParser();
		try (FileReader reader = new FileReader(fileName)) {
			Object obj = jsonParser.parse(reader);
			JSONArray userList = (JSONArray) obj;
			userList.forEach(user -> addFavouritesToHashmap((JSONObject) user));
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
	 * Helper method that handles a single users favourites in a JSON file
	 * @param user
	 */
	private static void addFavouritesToHashmap(JSONObject user) {
		
		LinkedList<POI> listOfFavs = new LinkedList<POI>();
		
		JSONObject userObject = (JSONObject) user.get("user");
		JSONObject favsList = (JSONObject) userObject.get("favourites");
		
		JSONArray alumniFavs = (JSONArray) favsList.get("alumni");
		for (int i = 0; i < alumniFavs.size(); i++) {
			POI poi = new POI((String) alumniFavs.get(i), "Alumni Hall", null, false);
			listOfFavs.add(poi);
		}
		JSONArray middlesexFavs = (JSONArray) favsList.get("middlesex");
		for (int i = 0; i < middlesexFavs.size(); i++) {
			POI poi = new POI((String) middlesexFavs.get(i), "Middlesex College", null, false);
			listOfFavs.add(poi);
		}
		JSONArray healthSciFavs = (JSONArray) favsList.get("healthsci");
		for (int i = 0; i < healthSciFavs.size(); i++) {
			POI poi = new POI((String) healthSciFavs.get(i), "Health Sciences Building", null, false);
			listOfFavs.add(poi);
		}
		favInfo.put((String) userObject.get("username"), new Favourite(listOfFavs));
	}
	
	/**
	 * Reads each users custom POIs from JSON and adds them to hash map
	 * @param fileName
	 */
	private static void buildUserPOIsHashmap(String fileName) {
		JSONParser jsonParser = new JSONParser();
		try (FileReader reader = new FileReader(fileName)) {
			Object obj = jsonParser.parse(reader);
			JSONArray userList = (JSONArray) obj;
			userList.forEach(user -> addUserPOIsToHashmap((JSONObject) user));
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
	 * Helper method to add a single users custom POIs to hash map
	 * @param user
	 */
	private static void addUserPOIsToHashmap(JSONObject user) {
		
		LinkedList<UserPOI> listOfUserPOIs = new LinkedList<UserPOI>();
		
		JSONObject userObject = (JSONObject) user.get("user");
		JSONObject userPOIsList = (JSONObject) userObject.get("userPOIs");
		
		JSONArray alumniUserPOIs = (JSONArray) userPOIsList.get("alumni");
		for (int i = 0; i < alumniUserPOIs.size(); i++) {
			UserPOI poi = new UserPOI((String) alumniUserPOIs.get(i), "Alumni Hall", null, false);
			listOfUserPOIs.add(poi);
		}
		JSONArray middlesexPOIs = (JSONArray) userPOIsList.get("middlesex");
		for (int i = 0; i < middlesexPOIs.size(); i++) {
			UserPOI poi = new UserPOI((String) middlesexPOIs.get(i), "Middlesex College", null, false);
			listOfUserPOIs.add(poi);
		}
		JSONArray healthSciPOIs = (JSONArray) userPOIsList.get("healthsci");
		for (int i = 0; i < healthSciPOIs.size(); i++) {
			UserPOI poi = new UserPOI((String) healthSciPOIs.get(i), "Health Sciences Building", null, false);
			listOfUserPOIs.add(poi);
		}
		customPOIInfo.put((String) userObject.get("username"), listOfUserPOIs);
	}
	
}