package uwoMaps;

import java.util.ArrayList;
import java.util.LinkedList;
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
 * This class will be used to edit users favourite POIs and write them to JSON files
 */

public class Favourite {
	
	/**
	 * @param favPOIs - Linked list to store POI objects that user has favourited
	 */
	public static LinkedList<POI> favPOIs = new LinkedList<POI>();
	
	/**
	 * Constructor
	 */
	public Favourite(LinkedList<POI> favPOIs) {
		this.favPOIs = favPOIs;
	}
	
	/**
	 * Return list of the users favourite POIs
	 */
	public ArrayList<POI> getListOfFavs() {
		return new ArrayList<POI>(favPOIs);
	}
	
	/**
	 * Add a POI to the list of users favourites and update JSON data
	 * @param poi
	 * @param id
	 */
	public void mark(POI poi, String id) {
		favPOIs.add(poi);
		JSONParser jsonParser = new JSONParser();
		try (FileReader reader = new FileReader("userData.json")) {
			Object obj = jsonParser.parse(reader);
			JSONArray userList = (JSONArray) obj;
			userList.forEach(user -> {
				JSONObject tempUser = (JSONObject) user;
				JSONObject userObject = (JSONObject) tempUser.get("user");
				if (userObject.get("username").equals(id)) {
					JSONObject favsList = (JSONObject) userObject.get("favourites");
					if (poi.getBuildingName().toLowerCase().contains("alumni")) {
						JSONArray alumniFavs = (JSONArray) favsList.get("alumni");
						String name = poi.getName();
						alumniFavs.add(name);
					}
					else if (poi.getBuildingName().toLowerCase().contains("middlesex")) {
						JSONArray middlesexFavs = (JSONArray) favsList.get("middlesex");
						String name = poi.getName();
						middlesexFavs.add(name);
					}
					else if (poi.getBuildingName().toLowerCase().contains("health")) {
						JSONArray healthSciFavs = (JSONArray) favsList.get("healthsci");
						String name = poi.getName();
						healthSciFavs.add(name);
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
	 * Remove a POI from the list of users favourites and update JSON file
	 * @param poi
	 * @param id
	 */
	public void unmark(POI poi, String id) {
		favPOIs.remove(poi);
		JSONParser jsonParser = new JSONParser();
		try (FileReader reader = new FileReader("userData.json")) {
			Object obj = jsonParser.parse(reader);
			JSONArray userList = (JSONArray) obj;
			userList.forEach(user -> {
				JSONObject tempUser = (JSONObject) user;
				JSONObject userObject = (JSONObject) tempUser.get("user");
				if (userObject.get("username").equals(id)) {
					JSONObject favsList = (JSONObject) userObject.get("favourites");
					if (poi.getBuildingName().toLowerCase().contains("alumni")) {
						JSONArray alumniFavs = (JSONArray) favsList.get("alumni");
						String name = poi.getName();
						for (int i = 0; i < alumniFavs.size(); i++) {
							if (alumniFavs.get(i).equals(name)) {
								alumniFavs.remove(i);
							}
						}
					}
					else if (poi.getBuildingName().toLowerCase().contains("middlesex")) {
						JSONArray middlesexFavs = (JSONArray) favsList.get("middlesex");
						String name = poi.getName();
						for (int i = 0; i < middlesexFavs.size(); i++) {
							if (middlesexFavs.get(i).equals(name)) {
								middlesexFavs.remove(i);
							}
						}
					}
					else if (poi.getBuildingName().toLowerCase().contains("health")) {
						JSONArray healthSciFavs = (JSONArray) favsList.get("healthsci");
						String name = poi.getName();
						for (int i = 0; i < healthSciFavs.size(); i++) {
							if (healthSciFavs.get(i).equals(name)) {
								healthSciFavs.remove(i);
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
	
	/**
	 * Returns an array of size 2 of the x and y coordinates of the POI taken in by the method
	 * @param poi
	 * @return
	 */
	public float[] showFav(POI poi) {
		if (poi instanceof regularPOI) {
			regularPOI isRegPOI = (regularPOI) poi;
			return new float[] {isRegPOI.posX, isRegPOI.posY};
		}
		else if (poi instanceof UserPOI) {
			UserPOI isUserPOI = (UserPOI) poi;
			return new float[] {isUserPOI.xCoordinate, isUserPOI.yCoordinate};
		}
		else {
			return null;
		}
	}	
}