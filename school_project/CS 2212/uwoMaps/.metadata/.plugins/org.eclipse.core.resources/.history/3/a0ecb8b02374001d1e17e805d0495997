package uwoMaps;

/**
 * @author Dayton Crombie, dcrombie@uwo.ca
 * @version 1.0
 * This class will be used to create regular POIs
 */

public class regularPOI extends POI{
	
	/*
	 * MetaData object associated with the built in point of interest,
	 * This is not a required instance variable for all regular POIs, 
	 * only for regularPOIs of the classroom category. 
	 */
	private MetaData metadata;
	
	/*
	 * The categories of the Built in POI can be classroom,
	 * navigation, washroom, CS, eateries, etc  
	 */
	private String category;
	/*
	 * The description is any extra details for the category: 
	 * navigation(stairwell, door, or elevator), CS(computer lab, 
	 * and collaborative room), washroom (male or female), etc
	 */
	private String description;
	
	/*
	 * X and Y positions on the floor that the Point of interest is located on
	 */
	public float posX;
	public float posY;
	
	
	/**
	 * Constructor that initializes instance variables for parent class
	 * 
	 * Variables for POI parent class:
	 * @param POIname - name of the point of interest
	 * @param floor - floor that the POI is associated with
	 * @param vis - whether or not the POI is visible on the map
	 * 
	 * Extra Variables: 
	 * @param cat - the category for the built in POI
	 */
	public regularPOI(String POIname, String buildingName, Floor floor, Boolean vis, String cat) {
		super(POIname, buildingName, floor, vis);
		category = cat;
	}

	/**
	 * Return meta data of regular POI
	 */
	public MetaData getMetadata() {
		return metadata;
	}

	/**
	 * Set meta data of regular POI
	 */
	public void setMetadata(MetaData metadata) {
		this.metadata = metadata;
	}
	
	/**
	 * Return category of the refular POI
	 */
	public String getCategory() {
		return category;
	}

	/**
	 * Return the description of the regular POI
	 */
	public String getDescription() {
		return description;
	}
	
	/**
	 * Set the description of regular POI
	 */
	public void setDescription(String descrip) {
		this.description = descrip;
	}
}