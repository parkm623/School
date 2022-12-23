package uwoMaps;

import java.util.ArrayList;
/**
 * 
 * @author Minsoo Park, mpark227@uwo.ca
 * @version 1.1
 * @since 1.0
 * 
 * This class represents the Building class which inheritance from CampusMap class
 * 
 * <p>
 * Building class is one of our main class which indicates names, position, address, and floors
 * <p>
 */

public class Building {
	
	/**
	 * @param buildingName - name of the building
	 * @param buildingAddress - address of the building
	 * @param numOfFloors - number of floors which are locating in current building
	 * @param currentFloor - represent current floor
	 * @param mode - indicate users' mode
	 * @param floor - list of floor
	 */
	public String buildingName;
	public String buildingAddress;
	public Integer numOfFloors;
	private Floor currentFloor;
	public String imageURL;
	
	public ArrayList<Floor> floors = new ArrayList<>();
	
	/*
	 * Constructor that initializes Building with null value
	 */
	public Building() {
		buildingName = null;
	}
	
	/*
	 * Constructor that initializes all the instance variables with provided data
	 */
	
	public Building(String name) {
		this.buildingName = name;
	}
	
	
	/**
	 * Gets the name of building
	 * @return buildingName
	 */
	public String getName() {
		return buildingName;
	}
	
	/**
	 * Gets the address of building
	 * @return buildingAddress
	 */
	public String getAddress() {
		return this.buildingAddress;
	}
	
	/**
	 * Sets the address of building
	 */
	public void setAddress(String address) {
		buildingAddress = address;
	}
	
	/**
	 * Gets the number of floors
	 * @return numOfFloors
	 */
	public Integer getNumofFloors() {
		return this.numOfFloors;
	}
	
	/**
	 * Gets the current floors
	 * @return currentFloor
	 */
	public Floor getFloor() {
		return this.currentFloor;
	}
	
	/**
	 * Sets the provided floor to current floor
	 */
	public void setFloor(Floor floor) {
		this.currentFloor = floor;
	}
	
	/**
	 * add selected floor to floor list
	 */
	public void addFloor(Floor targetFloor) {
		//check the mode
		if (true) {
			floors.add(targetFloor);
		}
	}
	
	/**
	 * add current floor to floor list
	 */
	public void addFloor() {
		if (true) {
			floors.add(this.currentFloor);
		}
	}
	
	/**
	 * remove target floor from floor list
	 */
	public void removeFloor (Floor targetFloor) {
		if (true) {
			if (floors.contains(targetFloor)) {
				floors.remove(targetFloor);
				numOfFloors = numOfFloors -1;
			}
		}
	}
	
	/**
	 * remove current floor from floor list
	 */
	public void removeFloor () {
		if (true) {
			if (floors.contains(this.currentFloor)) {
				floors.remove(this.currentFloor);
				numOfFloors = numOfFloors -1;
			}
		}
	}
}
