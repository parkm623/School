package uwoMaps;

/**
 * 
 * @author davidalter dalter4@uwo.ca
 * @version 1.2
 * @since 1.0
 * 
 * This class represents the basic template for a Point of Interest 
 * in our map application. 
 * 
 * <p>
 * From the POI class, there can either be Built in POIs in the western
 * university maps, or a custom POI that a user creates. Each POI regardless
 * of custom or not has a a floor that it is on and is associated with. 
 * <p>
 */
public class POI {
	/*
	 * Name of the Point of interest, also it's lookup value
	 */
	public String name;
	
	/*
	 * Indicates whether the POI is visible on the map 
	 */
	private Boolean visibility;
	
	/*
	 * Floor that the POI is located on
	 */
	private Floor onFloor;
	
	private String buildingName;
	
	/**
	 * Constructor that initializes all the instance variables
	 * @param POIname - name of the point of interest
	 * @param floor - floor that the POI is associated with
	 * @param vis - whether or not the POI is visible on the map
	 */
	public POI(String POIname, String buildingName, Floor floor , Boolean vis) {
		name = POIname;
		this.buildingName = buildingName;
		onFloor = floor;
		visibility = vis;
	}
	
	/**
	 * Returns the name of the POI
	 * @return
	 */
	public String getName() {
		return name;
	}
	
	/**
	 * Sets the name of the POI
	 * @param newName
	 */
	public void setName(String newName) {
		name = newName;
	}
	
	/**
	 * Return name of building POI is in
	 */
	public String getBuildingName() {
		return buildingName;
	}
	
	/**
	 * Set a new name of building the POI is in
	 */
	public void setBuildingName(String newName) {
		buildingName = newName;
	}
	
	/**
	 * Returns the floor that the POI is associated with
	 * @return onFloor
	 */
	public Floor getFloor() {
		return onFloor;
	}
	
	/**
	 * Sets the floor that the POI is asssociated with
	 * @param floor 
	 */
	public void setFloor(Floor floor) {
		this.onFloor = floor;
	}
	
	/**
	 * Method to change the visibility of the Point of interest on the Map
	 * @param value (True or False)
	 */
	public void setVisibility(boolean value) {
		visibility = value;
	}
}