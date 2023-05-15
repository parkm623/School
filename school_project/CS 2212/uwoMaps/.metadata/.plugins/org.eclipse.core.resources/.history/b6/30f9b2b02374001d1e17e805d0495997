package uwoMaps;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JTextField;

/**
 * 
 * @author Minsoo Park, mpark227@uwo.ca , David Alter dalter4@uwo.ca
 * @version 1.11
 * @since 1.0
 * 
 * This class represents the basic template for a Campus Map
 * 
 * <p>
 * CampusMap class is base of our map application. It has building list which contain
 * our main 3 buildings.
 * <p>
 */
public class CampusMap extends JFrame implements ActionListener{
	
	/**
	 * @param currentBuilding - current building
	 * @param first/second/last building - store the 3 building for now
	 * @param mode - indicate users' mode
	 * @param buildingList - list of building
	 */
	private Building currentBuilding;
	public Building firstBuilding = Main.MIDDLESEXCOLLEGE;
	public Building secondBuilding = Main.HEALTHSCIENCESBUILDING;
	public Building thirdBuilding = Main.ALUMNIHALL;
	
	ArrayList<Building> buildingList = new ArrayList<>();
	
	JLabel titleLabel = new JLabel("Building Maps");
	JLabel searchLabel = new JLabel("Search: ");
	JLabel searchNotFoundLabel = new JLabel("No POI found");
	
	JButton buildingBtn = new JButton("Building List");
	JButton helpBtn = new JButton("Help");
	JButton searchFieldButton = new JButton("Go");
	JButton firstBuildingButton = new JButton("First Building");
	JButton secondBuildingButton = new JButton("Second Building");
	JButton thirdBuildingButton = new JButton("Third Building");
	
	JButton backButton = new JButton("Go Back");
	
	boolean canEdit;
	JTextField searchField = new JTextField();
	
	/*
	 * Constructor that initializes all the instance variables
	 * setting the button and list frame
	 */
	public CampusMap() {
		
		Main.MFRAME.setVisible(false);
		Main.CMAP = this;
		
		//Next version should include way to store selected building data
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLayout(null);
		this.setSize(700,500);
		this.setLocationRelativeTo(null);
		this.setVisible(true);
		this.setTitle("Home");
		
		titleLabel.setBounds(130, 60, 200, 35);
		titleLabel.setFont(new Font(null, Font.BOLD, 20));
		
		searchLabel.setBounds(350, 80, 150, 40);
		searchFieldButton.setBounds(600, 120, 40, 40);
		searchFieldButton.addActionListener(this);
		searchNotFoundLabel.setBounds(350, 160, 150, 40);
		searchNotFoundLabel.setForeground(Color.red);
		searchNotFoundLabel.setVisible(false);
		searchField.setBounds(350, 120, 240, 40);
		searchField.setText("search for a class");
		
		buildingBtn.setBounds(380,200,140,30);
		buildingBtn.addActionListener(this);
		helpBtn.setBounds(380,340,140,30);
		helpBtn.addActionListener(this);
		backButton.setBounds(0, 0, 120, 40);
		backButton.addActionListener(this);
		
		firstBuildingButton.addActionListener(this);
		firstBuildingButton.setBounds(130, 100, 180, 40);
		firstBuildingButton.setText(firstBuilding.buildingName);
		
		secondBuildingButton.addActionListener(this);
		secondBuildingButton.setBounds(130, 180, 180, 40);
		secondBuildingButton.setText(secondBuilding.buildingName);
		
		thirdBuildingButton.addActionListener(this);
		thirdBuildingButton.setBounds(130, 260, 180, 40);
		thirdBuildingButton.setText(thirdBuilding.buildingName);
		
		buildingList.add(firstBuilding);
		buildingList.add(secondBuilding);
		buildingList.add(thirdBuilding);
		
		this.add(titleLabel);
		this.add(buildingBtn);

		this.add(helpBtn);
		this.add(firstBuildingButton);
		this.add(secondBuildingButton);
		this.add(thirdBuildingButton);
		this.add(backButton);
		this.add(searchLabel);
		this.add(searchField);
		this.add(searchNotFoundLabel);
		this.add(searchFieldButton);
		
		//added by dalter4@uwo.ca, checks the userdata if user can edit and sets the variable
		//if (Main.loginFRAME.userdata.canUserEdit(Main.MFRAME.user)) {
		//	canEdit = true;
		//} else {
		//	canEdit = false;
		//}
	}
	
	/**
	 * Gets the current building
	 * @return currentBuilding
	 */
	public Building getBuildings() {
		return currentBuilding;
	}
	
	/**
	 * Sets provided building to current building
	 */
	public void setBuilding(Building building) {
		currentBuilding = building;
	}
	
	
	/**
	 * add target building to building list
	 */
	public void addBuilding(Building targetBuilding) {
		//check the mode
			buildingList.add(targetBuilding);
	}
	
	/**
	 * add current building to building list
	 */
	public void addBuilding() {
			buildingList.add(this.currentBuilding);
	}
	
	/**
	 * remove target building from building list
	 */
	public void removeBuilding (Building targetBuilding) {
			if (buildingList.contains(targetBuilding)) {
				buildingList.remove(targetBuilding);
			}
	}
	/**
	 * remove current building from building list
	 */
	public void removeBuilding () {
			if (buildingList.contains(this.currentBuilding)) {
				buildingList.remove(this.currentBuilding);
			}
	}
	/**
	 * Test the button
	 * addBtn call the addBuilding method
	 * removeBtn call the removeBuilding method
	 * helpBtn call the Housekeeping class/frame
	 * buildingBtn show the list of current building list
	 */
	public void actionPerformed(ActionEvent e) {
		
		if (e.getSource() == firstBuildingButton) {
			setBuilding(firstBuilding);
			openBuilding(firstBuilding);
		}
		if (e.getSource() == secondBuildingButton) {
			setBuilding(secondBuilding);
			openBuilding(secondBuilding);
		}
		if (e.getSource() == thirdBuildingButton) {
			setBuilding(thirdBuilding);
			openBuilding(thirdBuilding);
		}
		if (e.getSource() == helpBtn) {
			//calling housekeeping class as new frame
			System.out.println("Use the buttons to navigate the application");
		}
		if (e.getSource() == buildingBtn) {
			JFrame f = new JFrame("Building List");
			f.add(new JList(buildingList.toArray()));
	        f.pack();
	        f.setLocationRelativeTo(null);
	        f.setSize(700,500);
	        f.setVisible(true);
		}
		if (e.getSource() == backButton) {
			Main.MFRAME.setVisible(true);
	        this.dispose();
		}
		if (e.getSource() == searchFieldButton) {
			//Get value of search field and loop through POIList to find it by name
			String search = searchField.getText();
			for (POI p : Main.POILIST) {
				if (p.getName().equals(search)) {
					Floor f = p.getFloor();
					Building b = f.locatedIn;
					//open the map in a new frame
					openPOI(b,f);
				}
			}
			searchNotFoundLabel.setVisible(true);
		}
	}
	
	public void openBuilding(Building b){
		BuildingPage bp = new BuildingPage(b);
	}
	
	public void openPOI(Building build, Floor f) {
		FloorPage fp = new FloorPage(build, f);
	}
}
