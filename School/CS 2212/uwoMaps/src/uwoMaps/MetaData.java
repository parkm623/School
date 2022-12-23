package uwoMaps;

import java.util.ArrayList;

/**
 * 
 * @author Taoran Gong, tgong9@uwo.ca
 * @version 1.0 The MetaData class is used to store extra information of
 *          building
 * 
 *
 */
public class MetaData {

	/**
	 * @param socialDisCapacity - indicate the social distance capacity
	 * @param classroom         - indicate which classroom will be used to show
	 *                          metadata
	 * @param roomType
	 * @param buildingName      - indicate which building the classroom is in
	 * @param seatingType       - indicate what is the seating type of that
	 *                          classroom
	 * @param projectionType    - indicate the type of projection
	 * @param AV                Equipment - The Audio Visual Technologies used in
	 *                          that classroom
	 */
	private String classroom;
	private Integer socialDisCapacity;
	private String roomType;
	private String buildingName;
	private String lectern;
	private String projectionType;
	private Integer seatingCapacity;

	ArrayList<String> windowTreatment = new ArrayList<String>();
	ArrayList<String> seatingType = new ArrayList<String>();
	ArrayList<String> AVEquip = new ArrayList<String>();
	ArrayList<String> writingSurface = new ArrayList<String>();

	/*
	 * Constructor that initializes classroom metadata with null value
	 * 
	 */
	public MetaData() {
		buildingName = null;
		classroom = null;
	}

	/*
	 * Constructor that takes in the information to indicate the metadata of that
	 * classroom
	 */
	public MetaData(String classroom, String buildingName) {
		this.buildingName = buildingName;
		this.classroom = classroom;
	}

	/*
	 * get which classroom it is
	 */
	public String getClassroom() {
		return classroom;
	}
	/*
	 * Set the classroom
	 */

	public void setClassroom(String classroom) {
		this.classroom = classroom;
	}

	/*
	 * Get the Lectern
	 */
	public String getLectern() {
		return lectern;
	}

	/*
	 * Set the lectern
	 */
	public void setLectern(String lectern) {
		this.lectern = lectern;
	}

	/*
	 * Get the social Distance Capacity of the classroom
	 */
	public int getSocialDisCapacity() {
		return socialDisCapacity;
	}

	/*
	 * Set the social distance capacity of one classroom
	 */
	public void setSocialDisCapacity(Integer socialDisCapacity) {
		this.socialDisCapacity = socialDisCapacity;
	}

	/*
	 * get the room type of the classroom (lecture, Boardroom, etc.)
	 */
	public String getRoomType() {
		return roomType;
	}

	/*
	 * Set the room type of one specific classroom
	 */
	public void setRoomType(String roomType) {
		this.roomType = roomType;
	}

	/*
	 * Get which building is the classroom in
	 */
	public String getBuildingName() {
		return buildingName;
	}

	/*
	 * Set which building that classroom is in
	 */

	public void setBuildingName(String buildingName) {
		this.buildingName = buildingName;
	}

	/*
	 * Get the projection Type of one classroom
	 */
	public String getProjectionType() {
		return projectionType;
	}
	/*
	 * Set the projection type of that classroom
	 */

	public void setProjectionType(String projectionType) {
		this.projectionType = projectionType;
	}

	/*
	 * Get the seating capacity of the classroom
	 */
	public Integer getSeatingCapacity() {
		return seatingCapacity;
	}

	/*
	 * Set the seating capacity of the classroom
	 */
	public void setSeatingCapacity(int seatingCapacity) {
		this.seatingCapacity = seatingCapacity;
	}

	/*
	 * Get the arrayList of audio/visual equipment
	 */
	public ArrayList<String> getAVEquip() {
		return AVEquip;
	}

	/*
	 * Add/Set the new audio/visual technology
	 */
	public void addAVEquip(String AVTech) {
		AVEquip.add(AVTech);
	}
	/*
	 * get the array list of seating type
	 */

	public ArrayList<String> getSeatingType() {
		return seatingType;
	}

	/*
	 * set/add the new seating type
	 */
	public void addSeatingType(String seatingtype) {
		seatingType.add(seatingtype);
	}

	/*
	 * Get the array list of new writing surface
	 */
	public ArrayList<String> getWritingSurface() {
		return writingSurface;
	}

	/*
	 * set/add new writing surface
	 */
	public void addWritingSurface(String writingsurface) {
		writingSurface.add(writingsurface);
	}
	/*
	 * get the array list of window treatment
	 */

	public ArrayList<String> getWindowTreatment() {
		return windowTreatment;
	}

	/*
	 * Set/add new window treatment
	 */
	public void addWindowTreatment(String curtainType) {
		windowTreatment.add(curtainType);
	}
}
