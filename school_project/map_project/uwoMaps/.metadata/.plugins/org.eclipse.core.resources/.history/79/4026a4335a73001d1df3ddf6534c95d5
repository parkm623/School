package uwoMaps;

import javax.swing.JButton;
import javax.swing.JFrame;
import java.awt.*;

public class Main {
	
	public static LoginPage loginFRAME;
	public static HomePage MFRAME;
	public static CampusMap CMAP;
	public static BuildingPage BPAGE;
	
	public static String CURRENTUSER;
	
	public static Building MIDDLESEXCOLLEGE;
	public static Building HEALTHSCIENCESBUILDING;
	public static Building ALUMNIHALL;
	public static UserData users;
	
	public static void main(String [] args) {
		
		getDefaultMap();
		//test user
		users = new UserData("1", "2");
		
		
		//Start the application by creating a loginFrame, passing in all the user data
		loginFRAME = new LoginPage(users.getLoginInfo());
		
		
	}
	
	/**
	 * function to Create and set the default buildings in the application, Middlesex college,
	 * Health Sciences Building, Alumni Hall
	 */
	
	public static void getDefaultMap() {
		
		/**
		 * Creating the middlesex college building
		 */
		Building middlesexCollege = new Building();
		middlesexCollege.numOfFloors = 5;
		middlesexCollege.buildingName = "Middlesex College";
		middlesexCollege.imageURL = "/MCimages/MC.png";
		
		/*
		 * Creating the five floors and setting images
		 */
		Floor mc1 = new Floor();
		mc1.floorNum = 1; 
		mc1.imageURL = "/MCimages/MC-1.png";
		mc1.accessibilityViewURL = "/MCimages/MC-1(A).png";
		mc1.washroomViewURL = "/MCimages/MC-1(W).png";
		mc1.blankViewURL = "/MCimages/MC-1(B).png";
		
		
		Floor mc2 = new Floor();
		mc2.floorNum = 2;
		mc2.imageURL = "/MCimages/MC-2.png";
		mc2.accessibilityViewURL = "/MCimages/MC-2(A).png";
		mc2.washroomViewURL = "/MCimages/MC-2(W).png";
		mc2.blankViewURL = "/MCimages/MC-2(B).png";
		
		Floor mc3 = new Floor();
		mc3.floorNum = 3;
		mc3.imageURL = "/MCimages/MC-3.png";
		mc3.accessibilityViewURL = "/MCimages/MC-3(A).png";
		mc3.washroomViewURL = "/MCimages/MC-3(W).png";
		mc3.blankViewURL = "/MCimages/MC-3(B).png";
		
		Floor mc4 = new Floor();
		mc4.floorNum = 4;
		mc4.imageURL = "/MCimages/MC-4.png";
		mc4.accessibilityViewURL = "/MCimages/MC-4(A).png";
		mc4.washroomViewURL = "/MCimages/MC-4(W).png";
		mc4.blankViewURL = "/MCimages/MC-4(B).png";
		
		Floor mc5 = new Floor();
		mc5.floorNum = 5;
		mc5.imageURL = "/MCimages/MC-5.png";
		mc5.accessibilityViewURL = "/MCimages/MC-5(A).png";
		mc5.washroomViewURL = "/MCimages/MC-5.png";
		mc5.blankViewURL = "/MCimages/MC-5(B).png";
		
		middlesexCollege.addFloor(mc1);
		middlesexCollege.addFloor(mc2);
		middlesexCollege.addFloor(mc3);
		middlesexCollege.addFloor(mc4);
		middlesexCollege.addFloor(mc5);
		
		
		/**
		 * Creating the health science building
		 */
		Building healthScienceBuilding = new Building();
		healthScienceBuilding.numOfFloors = 4;
		healthScienceBuilding.buildingName = "Health Sciences Building";
		healthScienceBuilding.imageURL = "/HSBimages/HSB.png";
		
		/*
		 * Creating the four floors and setting images
		 */
		Floor hsb1 = new Floor();
		hsb1.floorNum = 1;
		hsb1.imageURL = "/HSBimages/HSB-1.png";
		hsb1.accessibilityViewURL = "/HSBimages/HSB-1(A).png";
		hsb1.washroomViewURL = "/HSBimages/HSB-1(W).png";
		hsb1.blankViewURL = "/HSBimages/HSB-1(B).png";
		
		
		Floor hsb2 = new Floor();
		hsb2.floorNum = 2;
		hsb2.imageURL = "/HSBimages/HSB-2.png";
		hsb2.accessibilityViewURL = "/HSBimages/HSB-2(A).png";
		hsb2.washroomViewURL = "/HSBimages/HSB-2(W).png";
		hsb2.blankViewURL = "/HSBimages/HSB-2(B).png";
		
		Floor hsb3 = new Floor();
		hsb3.floorNum = 3;
		hsb3.imageURL = "/HSBimages/HSB-3.png";
		hsb3.accessibilityViewURL = "/HSBimages/HSB-3(A).png";
		hsb3.washroomViewURL = "/HSBimages/HSB-3(W).png";
		hsb3.blankViewURL = "/HSBimages/HSB-3(B).png";
		
		Floor hsb4 = new Floor();
		hsb4.floorNum = 4;
		hsb4.imageURL = "/HSBimages/HSB-4.png";
		hsb4.accessibilityViewURL = "/HSBimages/HSB-4(A).png";
		hsb4.washroomViewURL = "/HSBimages/HSB-4(W).png";
		hsb4.blankViewURL = "/HSBimages/HSB-4(B).png";
		
		healthScienceBuilding.addFloor(hsb1);
		healthScienceBuilding.addFloor(hsb2);
		healthScienceBuilding.addFloor(hsb3);
		healthScienceBuilding.addFloor(hsb4);
		
		/**
		 * Creating the alumni hall building
		 */
		Building alumniHall = new Building();
		alumniHall.numOfFloors = 3;
		alumniHall.buildingName = "Alumni Hall";
		alumniHall.imageURL = "/AHimages/AH.png";
		
		Floor ah1 = new Floor();
		ah1.floorNum = 1;
		ah1.imageURL = "/AHimages/AH-1.png";
		ah1.accessibilityViewURL = "/AHimages/AH-1(A).png";
		ah1.washroomViewURL = "/AHimages/AH-1(W).png";
		ah1.blankViewURL = "/AHimages/AH-1(B).png";
		
		Floor ah2 = new Floor();
		ah2.floorNum = 2;
		ah2.imageURL = "/AHimages/AH-2.png";
		ah2.accessibilityViewURL = "/AHimages/AH-2(A).png";
		ah2.washroomViewURL = "/AHimages/AH-2(W).png";
		ah2.blankViewURL = "/AHimages/AH-2(B).png";
		
		Floor ah3 = new Floor();
		ah3.floorNum = 3;
		ah3.imageURL = "/AHimages/AH-3.png";
		ah3.accessibilityViewURL = "/AHimages/AH-3(A).png";
		ah3.washroomViewURL = "/AHimages/AH-3.png";
		ah3.blankViewURL = "/AHimages/AH-3(B).png";
		
		alumniHall.addFloor(ah1);
		alumniHall.addFloor(ah2);
		alumniHall.addFloor(ah3);
		
		/*
		 *  Set buildings to main methods static variables so they can be used by JFrames
		 */
		MIDDLESEXCOLLEGE = middlesexCollege;
		HEALTHSCIENCESBUILDING = healthScienceBuilding;
		ALUMNIHALL = alumniHall;
	}
}
