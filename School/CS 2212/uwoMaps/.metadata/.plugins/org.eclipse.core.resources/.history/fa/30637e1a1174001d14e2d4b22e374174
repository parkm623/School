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
		Building healthScienceBuildingBuilding = new Building();
		healthScienceBuildingBuilding.numOfFloors = 4;
		healthScienceBuildingBuilding.buildingName = "Health Sciences Building";
		healthScienceBuildingBuilding.imageURL = "/HSBimages/HSB.png";
		
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
		
		healthScienceBuildingBuilding.addFloor(hsb1);
		healthScienceBuildingBuilding.addFloor(hsb2);
		healthScienceBuildingBuilding.addFloor(hsb3);
		healthScienceBuildingBuilding.addFloor(hsb4);
		
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
		HEALTHSCIENCESBUILDING = healthScienceBuildingBuilding;
		ALUMNIHALL = alumniHall;
		
		/*	Start to set POIs
		 *  Set POIs to AH1 floor
		 */
		regularPOI AHstairwell1F1 = new regularPOI("AH stairwell 1", alumniHall.buildingName ,ah1, true, "Accessibility");
		regularPOI AHstairwell2F1 = new regularPOI("AH stairwell 2", alumniHall.buildingName ,ah1, true, "Accessibility");
		regularPOI AHstairwell3F1 = new regularPOI("AH stairwell 3", alumniHall.buildingName ,ah1, true, "Accessibility");
		regularPOI AHstairwell4F1 = new regularPOI("AH stairwell 4", alumniHall.buildingName ,ah1, true, "Accessibility");
		regularPOI AHelevator1F1 = new regularPOI("AH Elevator 1", alumniHall.buildingName ,ah1, true, "Accessibility");
		
		ah1.POIs.add(AHstairwell1F1); 
		ah1.POIs.add(AHstairwell2F1); 
		ah1.POIs.add(AHstairwell3F1); 
		ah1.POIs.add(AHstairwell4F1); 
		ah1.POIs.add(AHelevator1F1); 
		
		regularPOI AHwashroom12F1 = new regularPOI("AH washroom 12 – Men", alumniHall.buildingName ,ah1, true, "Washroom");
		regularPOI AHwashroom13F1 = new regularPOI("AH washroom 13 – Woman", alumniHall.buildingName ,ah1, true, "Washroom");
		
		ah1.POIs.add(AHwashroom12F1); 
		ah1.POIs.add(AHwashroom13F1); 
		
		/*
		 *  Set POIs to AH2 floor
		 */
		regularPOI AHstairwell1F2 = new regularPOI("AH stairwell 1", alumniHall.buildingName ,ah2, true, "Accessibility");
		regularPOI AHstairwell2F2 = new regularPOI("AH stairwell 2", alumniHall.buildingName ,ah2, true, "Accessibility");
		regularPOI AHstairwell3F2 = new regularPOI("AH stairwell 3", alumniHall.buildingName ,ah2, true, "Accessibility");
		regularPOI AHstairwell4F2 = new regularPOI("AH stairwell 4", alumniHall.buildingName ,ah2, true, "Accessibility");
		regularPOI AHelevator1F2 = new regularPOI("AH Elevator 1", alumniHall.buildingName ,ah2, true, "Accessibility");
		regularPOI AHexit1F2 = new regularPOI("AH Exit 1", alumniHall.buildingName ,ah2, true, "Accessibility");
		regularPOI AHexit2F2 = new regularPOI("AH Exit 2", alumniHall.buildingName ,ah2, true, "Accessibility");
		regularPOI AHexit9F2 = new regularPOI("AH Exit 9", alumniHall.buildingName ,ah2, true, "Accessibility");
		
		ah2.POIs.add(AHstairwell1F2); 
		ah2.POIs.add(AHstairwell2F2); 
		ah2.POIs.add(AHstairwell3F2); 
		ah2.POIs.add(AHstairwell4F2); 
		ah2.POIs.add(AHelevator1F2);
		ah2.POIs.add(AHexit1F2);
		ah2.POIs.add(AHexit2F2);
		ah2.POIs.add(AHexit9F2);
		
		regularPOI AHwashroom102F2 = new regularPOI("AH washroom 102 – Woman", alumniHall.buildingName ,ah2, true, "Washroom");
		regularPOI AHwashroom103F2 = new regularPOI("AH washroom 103 – Universal", alumniHall.buildingName ,ah2, true, "Washroom");
		regularPOI AHwashroom108F2 = new regularPOI("AH washroom 108 – Men", alumniHall.buildingName ,ah2, true, "Washroom");
		regularPOI AHwashroom109F2 = new regularPOI("AH washroom 109 – Universal", alumniHall.buildingName ,ah2, true, "Washroom"); 
		
		ah2.POIs.add(AHwashroom102F2); 
		ah2.POIs.add(AHwashroom103F2); 
		ah2.POIs.add(AHwashroom108F2); 
		ah2.POIs.add(AHwashroom109F2); 
		
		regularPOI AHclassroom101F2 = new regularPOI("AH Classroom 101", alumniHall.buildingName ,ah2, true, "Classroom");
		
		ah2.POIs.add(AHclassroom101F2); 
		
		/*
		 *  Set POIs to AH3 floor
		 */
		regularPOI AHstairwell1F3 = new regularPOI("AH stairwell 1", alumniHall.buildingName ,ah3, true, "Accessibility");
		regularPOI AHstairwell2F3 = new regularPOI("AH stairwell 2", alumniHall.buildingName ,ah3, true, "Accessibility");
		regularPOI AHstairwell3F3 = new regularPOI("AH stairwell 3", alumniHall.buildingName ,ah3, true, "Accessibility");
		regularPOI AHstairwell4F3 = new regularPOI("AH stairwell 4", alumniHall.buildingName ,ah3, true, "Accessibility");
		regularPOI AHstairwell5F3 = new regularPOI("AH stairwell 5", alumniHall.buildingName ,ah3, true, "Accessibility");
		regularPOI AHelevator1F3 = new regularPOI("AH Elevator 1", alumniHall.buildingName ,ah3, true, "Accessibility");
		regularPOI AHexit6F3 = new regularPOI("AH Exit 6", alumniHall.buildingName ,ah3, true, "Accessibility");
		regularPOI AHexit7F3 = new regularPOI("AH Exit 7", alumniHall.buildingName ,ah3, true, "Accessibility");
		regularPOI AHexit8F3 = new regularPOI("AH Exit 8", alumniHall.buildingName ,ah3, true, "Accessibility");
		
		ah3.POIs.add(AHstairwell1F3); 
		ah3.POIs.add(AHstairwell2F3); 
		ah3.POIs.add(AHstairwell3F3); 
		ah3.POIs.add(AHstairwell4F3); 
		ah3.POIs.add(AHstairwell5F3);
		ah3.POIs.add(AHelevator1F3);
		ah3.POIs.add(AHexit6F3);
		ah3.POIs.add(AHexit7F3);
		ah3.POIs.add(AHexit8F3);
		
		/*
		 *  Set POIs to HSB1 floor
		 */
		regularPOI HSBstairwell1F1 = new regularPOI("HSB stairwell 1", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		regularPOI HSBstairwell2F1 = new regularPOI("HSB stairwell 2", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		regularPOI HSBstairwell3F1 = new regularPOI("HSB stairwell 3", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		regularPOI HSBelevator1F1 = new regularPOI("HSB Elevator 1", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		regularPOI HSBelevator2F1 = new regularPOI("HSB Elevator 2", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		regularPOI HSBexit1F1 = new regularPOI("HSB Exit 1", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		regularPOI HSBexit2F1 = new regularPOI("HSB Exit 2", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		regularPOI HSBexit3F1 = new regularPOI("HSB Exit 3", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		regularPOI HSBexit4F1 = new regularPOI("HSB Exit 4", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		regularPOI HSBexit5F1 = new regularPOI("HSB Exit 5", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		regularPOI HSBexit6F1 = new regularPOI("HSB Exit 6", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		regularPOI HSBexit7F1 = new regularPOI("HSB Exit 7", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Accessibility");
		
		hsb1.POIs.add(HSBstairwell1F1); 
		hsb1.POIs.add(HSBstairwell2F1); 
		hsb1.POIs.add(HSBstairwell3F1); 
		hsb1.POIs.add(HSBelevator1F1); 
		hsb1.POIs.add(HSBelevator2F1); 
		hsb1.POIs.add(HSBexit1F1); 
		hsb1.POIs.add(HSBexit2F1); 
		hsb1.POIs.add(HSBexit3F1); 
		hsb1.POIs.add(HSBexit4F1); 
		hsb1.POIs.add(HSBexit5F1); 
		hsb1.POIs.add(HSBexit6F1); 
		hsb1.POIs.add(HSBexit7F1); 
		
		regularPOI HSBwashroom20F1 = new regularPOI("HSB Washroom 20 - Women", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Washroom");
		regularPOI HSBwashroom22F1 = new regularPOI("HSB Washroom 22 - Men", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Washroom");
		
		hsb1.POIs.add(HSBwashroom20F1);
		hsb1.POIs.add(HSBwashroom22F1);  
		
		regularPOI HSBclassroom9F1 = new regularPOI("HSB Classroom 9", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Classroom");
		regularPOI HSBclassroom11F1 = new regularPOI("HSB Classroom 11", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Classroom");
		regularPOI HSBclassroom35F1 = new regularPOI("HSB Classroom 35", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Classroom");
		regularPOI HSBclassroom40F1 = new regularPOI("HSB Classroom 40", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Classroom");
		
		hsb1.POIs.add(HSBclassroom9F1); 
		hsb1.POIs.add(HSBclassroom11F1);
		hsb1.POIs.add(HSBclassroom35F1);
		hsb1.POIs.add(HSBclassroom40F1);
		
		regularPOI HSBtimhortonsF1 = new regularPOI("HSB Tim Hortons", healthScienceBuildingBuilding.buildingName ,hsb1, true, "Eatery");
		
		hsb1.POIs.add(HSBtimhortonsF1);
		
		/*
		 * 	Set POIs to HSB2 floor
		 */
		regularPOI HSBstairwell1F2 = new regularPOI("HSB stairwell 1", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Accessibility");
		regularPOI HSBstairwell2F2 = new regularPOI("HSB stairwell 2", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Accessibility");
		regularPOI HSBstairwell3F2 = new regularPOI("HSB stairwell 3", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Accessibility");
		regularPOI HSBstairwell4F2 = new regularPOI("HSB stairwell 4", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Accessibility");
		regularPOI HSBstairwell5F2 = new regularPOI("HSB stairwell 5", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Accessibility");
		regularPOI HSBelevator1F2 = new regularPOI("HSB Elevator 1", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Accessibility");
		regularPOI HSBelevator2F2 = new regularPOI("HSB Elevator 2", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Accessibility");
		
		hsb2.POIs.add(HSBstairwell1F2); 
		hsb2.POIs.add(HSBstairwell2F2); 
		hsb2.POIs.add(HSBstairwell3F2); 
		hsb2.POIs.add(HSBstairwell4F2); 
		hsb2.POIs.add(HSBstairwell5F2); 
		hsb2.POIs.add(HSBelevator1F2); 
		hsb2.POIs.add(HSBelevator2F2); 
		
		regularPOI HSBwashroom200F2 = new regularPOI("HSB Washroom 200 - Universal", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Washroom");
		regularPOI HSBwashroom226F2 = new regularPOI("HSB Washroom 226 - Women", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Washroom");
		regularPOI HSBwashroom228F2 = new regularPOI("HSB Washroom 228 - Men", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Washroom");
		
		hsb2.POIs.add(HSBwashroom200F2);
		hsb2.POIs.add(HSBwashroom226F2);  
		hsb2.POIs.add(HSBwashroom228F2);  
		
		regularPOI HSBclassroom236F2 = new regularPOI("HSB Classroom 236", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Classroom");
		regularPOI HSBclassroom240F2 = new regularPOI("HSB Classroom 240", healthScienceBuildingBuilding.buildingName ,hsb2, true, "Classroom");
		
		hsb2.POIs.add(HSBclassroom236F2); 
		hsb2.POIs.add(HSBclassroom240F2);
		
		/*
		 * 	Set POIs to HSB3 floor
		 */
		regularPOI HSBstairwell1F3 = new regularPOI("HSB stairwell 1", healthScienceBuildingBuilding.buildingName ,hsb3, true, "Accessibility");
		regularPOI HSBstairwell2F3 = new regularPOI("HSB stairwell 2", healthScienceBuildingBuilding.buildingName ,hsb3, true, "Accessibility");
		regularPOI HSBelevator1F3 = new regularPOI("HSB Elevator 1", healthScienceBuildingBuilding.buildingName ,hsb3, true, "Accessibility");
		regularPOI HSBelevator2F3 = new regularPOI("HSB Elevator 2", healthScienceBuildingBuilding.buildingName ,hsb3, true, "Accessibility");
		
		hsb3.POIs.add(HSBstairwell1F3); 
		hsb3.POIs.add(HSBstairwell2F3);
		hsb3.POIs.add(HSBelevator1F3);
		hsb3.POIs.add(HSBelevator2F3);
		
		regularPOI HSBwashroom320F3 = new regularPOI("HSB Washroom 320 - Women", healthScienceBuildingBuilding.buildingName ,hsb3, true, "Washroom");
		regularPOI HSBwashroom325F3 = new regularPOI("HSB Washroom 325 - Men", healthScienceBuildingBuilding.buildingName ,hsb3, true, "Washroom");
		
		hsb3.POIs.add(HSBwashroom320F3);
		hsb3.POIs.add(HSBwashroom325F3);
		
		/*
		 * 	Set POIs to HSB4 floor
		 */
		regularPOI HSBstairwell1F4 = new regularPOI("HSB stairwell 1", healthScienceBuildingBuilding.buildingName ,hsb4, true, "Accessibility");
		regularPOI HSBstairwell2F4 = new regularPOI("HSB stairwell 2", healthScienceBuildingBuilding.buildingName ,hsb4, true, "Accessibility");
		regularPOI HSBelevator1F4 = new regularPOI("HSB Elevator 1", healthScienceBuildingBuilding.buildingName ,hsb4, true, "Accessibility");
		regularPOI HSBelevator2F4 = new regularPOI("HSB Elevator 2", healthScienceBuildingBuilding.buildingName ,hsb4, true, "Accessibility");
		
		hsb4.POIs.add(HSBstairwell1F4); 
		hsb4.POIs.add(HSBstairwell2F4); 
		hsb4.POIs.add(HSBelevator1F4); 
		hsb4.POIs.add(HSBelevator2F4); 
		
		regularPOI HSBwashroom420F4 = new regularPOI("HSB Washroom 420 - Women", healthScienceBuildingBuilding.buildingName ,hsb4, true, "Washroom");
		regularPOI HSBwashroom422F4 = new regularPOI("HSB Washroom 422 - Universal", healthScienceBuildingBuilding.buildingName ,hsb4, true, "Washroom");
		regularPOI HSBwashroom423F4 = new regularPOI("HSB Washroom 423 - Men", healthScienceBuildingBuilding.buildingName ,hsb4, true, "Washroom");
		
		hsb4.POIs.add(HSBwashroom420F4); 
		hsb4.POIs.add(HSBwashroom422F4); 
		hsb4.POIs.add(HSBwashroom423F4); 
		
		/*
		 * 	Set POIs to MC1 floor
		 */
		regularPOI MCstairwell1F1 = new regularPOI("MC stairwell 1", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCstairwell2F1 = new regularPOI("MC stairwell 2", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCstairwell3F1 = new regularPOI("MC stairwell 3", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCstairwell4F1 = new regularPOI("MC stairwell 4", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCstairwell5F1 = new regularPOI("MC stairwell 5", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCstairwell6F1 = new regularPOI("MC stairwell 6", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCelevator1F1 = new regularPOI("MC Elevator 1", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCelevator2F1 = new regularPOI("MC Elevator 2", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCexit1F1 = new regularPOI("MC Exit 1", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCexit2F1 = new regularPOI("MC Exit 2", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCexit3F1 = new regularPOI("MC Exit 3", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCexit4F1 = new regularPOI("MC Exit 4", middlesexCollege.buildingName ,mc1, true, "Accessibility");
		regularPOI MCexit5F1 = new regularPOI("MC Exit 5", middlesexCollege.buildingName ,mc1, true, "Accessibility");

		
		mc1.POIs.add(MCstairwell1F1);
		mc1.POIs.add(MCstairwell2F1);
		mc1.POIs.add(MCstairwell3F1);
		mc1.POIs.add(MCstairwell4F1);
		mc1.POIs.add(MCstairwell5F1);
		mc1.POIs.add(MCstairwell6F1);
		mc1.POIs.add(MCelevator1F1);
		mc1.POIs.add(MCelevator2F1);
		mc1.POIs.add(MCexit1F1);
		mc1.POIs.add(MCexit2F1);
		mc1.POIs.add(MCexit3F1);
		mc1.POIs.add(MCexit4F1);
		mc1.POIs.add(MCexit5F1);
		
		regularPOI MCBwashroom4BF1 = new regularPOI("MC Washroom 4B - Women", middlesexCollege.buildingName ,mc1, true, "Washroom");
		regularPOI MCBwashroom4CF1 = new regularPOI("MC Washroom 4C - Universal", middlesexCollege.buildingName ,mc1, true, "Washroom");
		regularPOI MCBwashroom5BF1 = new regularPOI("MC Washroom 5B - Men", middlesexCollege.buildingName ,mc1, true, "Washroom");
		regularPOI MCBwashroom28EF1 = new regularPOI("MC Washroom 28E - Men", middlesexCollege.buildingName ,mc1, true, "Washroom");
		
		mc1.POIs.add(MCBwashroom4BF1);
		mc1.POIs.add(MCBwashroom4CF1);
		mc1.POIs.add(MCBwashroom5BF1);
		mc1.POIs.add(MCBwashroom28EF1);
		
		regularPOI MCclassroom17F1 = new regularPOI("MC Classroom 17", middlesexCollege.buildingName ,mc1, true, "Classroom");
		
		mc1.POIs.add(MCclassroom17F1);
		
		regularPOI MCgradclubF1 = new regularPOI("MC Grad Club", middlesexCollege.buildingName ,mc1, true, "Eatery");
		
		mc1.POIs.add(MCgradclubF1);
		
		/*
		 * 	Set POIs to MC2 floor
		 */
		regularPOI MCstairwell1F2 = new regularPOI("MC stairwell 1", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCstairwell2F2 = new regularPOI("MC stairwell 2", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCstairwell3F2 = new regularPOI("MC stairwell 3", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCstairwell4F2 = new regularPOI("MC stairwell 4", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCelevator1F2 = new regularPOI("MC Elevator 1", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCelevator2F2 = new regularPOI("MC Elevator 2", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCexit1F2 = new regularPOI("MC Exit 1", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCexit2F2 = new regularPOI("MC Exit 2", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCexit3F2 = new regularPOI("MC Exit 3", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCexit4F2 = new regularPOI("MC Exit 4", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCexit5F2 = new regularPOI("MC Exit 5", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCexit6F2 = new regularPOI("MC Exit 6", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		regularPOI MCexit7F2 = new regularPOI("MC Exit 7", middlesexCollege.buildingName ,mc2, true, "Accessibility");
		
		mc2.POIs.add(MCstairwell1F2);
		mc2.POIs.add(MCstairwell2F2);
		mc2.POIs.add(MCstairwell3F2);
		mc2.POIs.add(MCstairwell4F2);
		mc2.POIs.add(MCelevator1F2);
		mc2.POIs.add(MCelevator2F2);
		mc2.POIs.add(MCexit1F2);
		mc2.POIs.add(MCexit2F2);
		mc2.POIs.add(MCexit3F2);
		mc2.POIs.add(MCexit4F2);
		mc2.POIs.add(MCexit5F2);
		mc2.POIs.add(MCexit6F2);
		mc2.POIs.add(MCexit7F2);
		regularPOI MCBwashroom100BF2 = new regularPOI("MC Washroom 100 - Men", middlesexCollege.buildingName ,mc2, true, "Washroom");
		regularPOI MCBwashroom139CF2 = new regularPOI("MC Washroom 139 - Women", middlesexCollege.buildingName ,mc2, true, "Washroom");
		
		mc2.POIs.add(MCBwashroom100BF2);
		mc2.POIs.add(MCBwashroom139CF2);
		
		regularPOI MCclassroom105F2 = new regularPOI("MC Classroom 105", middlesexCollege.buildingName ,mc2, true, "Classroom");
		regularPOI MCclassroom110F2 = new regularPOI("MC Classroom 110", middlesexCollege.buildingName ,mc2, true, "Classroom");
		
		mc2.POIs.add(MCclassroom105F2);
		mc2.POIs.add(MCclassroom110F2);
		
		/*
		 * 	Set POIs to MC3 floor
		 */
		regularPOI MCstairwell1F3 = new regularPOI("MC stairwell 1", middlesexCollege.buildingName ,mc3, true, "Accessibility");
		regularPOI MCstairwell2F3 = new regularPOI("MC stairwell 2", middlesexCollege.buildingName ,mc3, true, "Accessibility");
		regularPOI MCstairwell3F3 = new regularPOI("MC stairwell 3", middlesexCollege.buildingName ,mc3, true, "Accessibility");
		regularPOI MCstairwell4F3 = new regularPOI("MC stairwell 4", middlesexCollege.buildingName ,mc3, true, "Accessibility");
		regularPOI MCelevator1F3 = new regularPOI("MC Elevator 1", middlesexCollege.buildingName ,mc3, true, "Accessibility");
		regularPOI MCelevator2F3 = new regularPOI("MC Elevator 2", middlesexCollege.buildingName ,mc3, true, "Accessibility");
		
		mc3.POIs.add(MCstairwell1F3);
		mc3.POIs.add(MCstairwell2F3);
		mc3.POIs.add(MCstairwell3F3);
		mc3.POIs.add(MCstairwell4F3);
		mc3.POIs.add(MCelevator1F3);
		mc3.POIs.add(MCelevator2F3);
		
		regularPOI MCBwashroom205BF3 = new regularPOI("MC Washroom 205 - Women", middlesexCollege.buildingName ,mc3, true, "Washroom");
		regularPOI MCBwashroom278BF3 = new regularPOI("MC Washroom 278 - Women", middlesexCollege.buildingName ,mc3, true, "Washroom");
		
		mc3.POIs.add(MCBwashroom205BF3);
		mc3.POIs.add(MCBwashroom278BF3);
		
		regularPOI Mclab230F3 = new regularPOI("MC Lab 230", middlesexCollege.buildingName ,mc3, true, "Lab");
		regularPOI Mclab235F3 = new regularPOI("MC Lab 235", middlesexCollege.buildingName ,mc3, true, "Lab");
		regularPOI Mclab240F3 = new regularPOI("MC Lab 240", middlesexCollege.buildingName ,mc3, true, "Lab");
		regularPOI Mclab245F3 = new regularPOI("MC Lab 245", middlesexCollege.buildingName ,mc3, true, "Lab");
		regularPOI Mccollabo220F3 = new regularPOI("MC Collaborative Space 220", middlesexCollege.buildingName ,mc3, true, "Collabo");
		regularPOI Mccollabo239F3 = new regularPOI("MC Collaborative Space 239", middlesexCollege.buildingName ,mc3, true, "Collabo");
		
		mc3.POIs.add(Mclab230F3);
		mc3.POIs.add(Mclab235F3);
		mc3.POIs.add(Mclab240F3);
		mc3.POIs.add(Mclab245F3);
		mc3.POIs.add(Mccollabo220F3);
		mc3.POIs.add(Mccollabo239F3);
		
		/*
		 * 	Set POIs to MC4 floor
		 */
		regularPOI MCstairwell1F4 = new regularPOI("MC stairwell 1", middlesexCollege.buildingName ,mc4, true, "Accessibility");
		regularPOI MCstairwell2F4 = new regularPOI("MC stairwell 2", middlesexCollege.buildingName ,mc4, true, "Accessibility");
		regularPOI MCstairwell3F4 = new regularPOI("MC stairwell 3", middlesexCollege.buildingName ,mc4, true, "Accessibility");
		regularPOI MCstairwell4F4 = new regularPOI("MC stairwell 4", middlesexCollege.buildingName ,mc4, true, "Accessibility");
		regularPOI MCelevator1F4 = new regularPOI("MC Elevator 1", middlesexCollege.buildingName ,mc4, true, "Accessibility");
		regularPOI MCelevator2F4 = new regularPOI("MC Elevator 2", middlesexCollege.buildingName ,mc4, true, "Accessibility");
		
		mc4.POIs.add(MCstairwell1F4);
		mc4.POIs.add(MCstairwell2F4);
		mc4.POIs.add(MCstairwell3F4);
		mc4.POIs.add(MCstairwell4F4);
		mc4.POIs.add(MCelevator1F4);
		mc4.POIs.add(MCelevator2F4);
		
		regularPOI MCBwashroom311BF4 = new regularPOI("MC Washroom 311 - Men", middlesexCollege.buildingName ,mc4, true, "Washroom");
		regularPOI MCBwashroom388BF4 = new regularPOI("MC Washroom 388 - Women", middlesexCollege.buildingName ,mc4, true, "Washroom");
		
		mc4.POIs.add(MCBwashroom311BF4);
		mc4.POIs.add(MCBwashroom388BF4);
		
		regularPOI MCclassroom316F4 = new regularPOI("MC Classroom 316", middlesexCollege.buildingName ,mc4, true, "Classroom");
		regularPOI MCclassroom320F4 = new regularPOI("MC Classroom 320", middlesexCollege.buildingName ,mc4, true, "Classroom");
		regularPOI MCseminar300F4= new regularPOI("MC Seminar 300", middlesexCollege.buildingName ,mc4, true, "Seminar");
		regularPOI Mclab342F4 = new regularPOI("MC Lab 342", middlesexCollege.buildingName ,mc4, true, "Lab");
		regularPOI Mccollabo325F3 = new regularPOI("MC Collaborative Space 325", middlesexCollege.buildingName ,mc4, true, "Collabo");
		
		mc4.POIs.add(MCclassroom316F4);
		mc4.POIs.add(MCclassroom320F4);
		mc4.POIs.add(MCseminar300F4);
		mc4.POIs.add(Mclab342F4);
		mc4.POIs.add(Mccollabo325F3);
		
		/*
		 * 	Set POIs to MC5 floor
		 */
		regularPOI MCstairwell1F5 = new regularPOI("MC stairwell 1", middlesexCollege.buildingName ,mc5, true, "Accessibility");
		regularPOI MCstairwell2F5 = new regularPOI("MC stairwell 2", middlesexCollege.buildingName ,mc5, true, "Accessibility");
		regularPOI MCelevator1F5 = new regularPOI("MC Elevator 1", middlesexCollege.buildingName ,mc5, true, "Accessibility");
		
		mc5.POIs.add(MCstairwell1F5);
		mc5.POIs.add(MCstairwell2F5);
		mc5.POIs.add(MCelevator1F5);
	}
	
}
