package uwoMaps;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Image;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

import uwoMaps.Building;

/**
 * 
 * @author david alter <dalter4@uwo.ca>
 * @version 1.13
 * @since 1.0
 * 
 * This class represents the floorpage, which the user gets taken to after the pick a floor number
 * on a building in the buildingPage. From here, you are able to add custom POIs, add POIs to your favourites,
 * and list all the POIs on the floor in question
 * 
 * <p>
 * This class is set up dynamically so it will open the correct blueprint in the correct building,
 * while still keeping the functionality
 * <p>
 */

public class FloorPage extends JFrame implements ActionListener{
	
	/*
	 * Building that the floor is inside of
	 */
	Building insideOf;
	/*
	 * Floor that is associated with page (user selected)
	 */
	Floor floor;
	
	/*
	 * Check variable to see if certain labels should be displayed, if a user clicks on
	 * the map, this gets set to true 
	 */
	boolean isPinDropped; 
	
	/*
	 * X position of selector pin
	 */
	int pinPointX;
	/*
	 * Y position of selector pin
	 */
	int pinPointY;
	
	/*
	 * POI view of blueprint
	 */
	private ImageIcon img;
	/*
	 * Accessibility view of blueprint, same image with elevators only
	 */
	private ImageIcon accessImg;
	/*
	 * Washroom view of blueprint, same image with washrooms only
	 */
	private ImageIcon washroomImg;
	/*
	 * Plain view of blueprint, nothing highlighted
	 */
	private ImageIcon plainImg;
	/*
	 * Image of a red pin, pops up when a user clicks on the map (selector pin)
	 */
	private ImageIcon pin;
	/*
	 * Image of purple pin, to signify that a custom POI has been placed
	 */
	private ImageIcon customPOIPin;
	/*
	 * Label to put selector pin on
	 */
	private JLabel pinLabel;
	/*
	 * Label to put Custom POI pin on
	 */
	private JLabel purplePinLabel;
	/*
	 * Label to put correct image of map on
	 */
	private JLabel floorMap;
	/*
	 * Panel to put floorMap Label on in the JFrame
	 */
	private JPanel background = new JPanel();
	
	/*
	 * panel that is used to collect information about adding to favourites  list
	 */
	private JPanel enterFavInfoPanel = new JPanel();
	/*
	 * panel that is used to collect information about creating a custom POI
	 */
	private JPanel enterCustomInfoPanel = new JPanel();
	/*
	 *panel that is used to output a list of POIs on the given floor 
	 */
	private JPanel poiOutputPanel = new JPanel();
	
	/*
	 * Label that will only show up if the POI has been successfully added to favourites list
	 */
	private JLabel favAddedSuccessLabel = new JLabel("POI added to Favourites");
	private JLabel customAddedSuccessLabel = new JLabel("New Custom POI added");
	
	/*
	 * Label that will list all POIs
	 */
	private JLabel poiOutputLabel = new JLabel("");
	
	/*
	 * Various operation buttons to close panels or go back to the buildingPage
	 */
	JButton backButton = new JButton("Go back");
	JButton closeAddFavButton = new JButton("Cancel");
	JButton closeAddCustomButton = new JButton("Cancel");
	JButton closePoiOutputButton = new JButton("X");
	
	/*
	 *Zoom in, Zoom out buttons, currently no functionality 
	 */
	JButton zoomInButton = new JButton("+");
	JButton zoomOutButton= new JButton("-");
	
	/*
	 *Input fields to go on various Panels 
	 */
	JTextField favPOINameField = new JTextField();
	JTextField favPOIDescriptionField = new JTextField();
	JTextField customNameField = new JTextField();
	JTextField customDescriptionField = new JTextField();
	
	JLabel favPOINameLabel = new JLabel("Name: ");
	JLabel favPOIDescriptionLabel = new JLabel("Description: ");
	JLabel customNameLabel = new JLabel("Name: ");
	JLabel customDescriptionLabel = new JLabel("Descitpion: ");
	
	JButton listPOIsButton = new JButton("List all POIs");
	JButton createPOIButton = new JButton("Create Custom POI");
	JButton addToFavButton = new JButton("Add to Favourites");
	JButton submitFavButton = new JButton("Add to my Favourites");
	JButton submitCustomButton = new JButton("Add Custom POI");
	
	/*
	 * Combo Box to pick which view the user wants to see
	 */
	JComboBox viewChoice; 
	

	public FloorPage(Building build, Floor f) {
		//Main.BPAGE.setVisible(false);
		insideOf = build;
		floor = f;
		isPinDropped = false;
		
		/*
		 * Set screen size to full screen
		 */
		Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
		
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLayout(null);
		this.setSize(screenSize);
		this.setVisible(true);
		this.setLocationRelativeTo(null);
		this.setTitle(build.buildingName + " Floor " + f.floorNum);
		
		
		String[] options = {"POI View", "Accessibility View", "Washroom View" , "Plain View"};
		viewChoice = new JComboBox(options);
		viewChoice.setBounds(getWidth() - 140, 20, 120, 60);
		viewChoice.addActionListener(this);
		
		img = new ImageIcon(getClass().getResource(f.imageURL));
		img = new ImageIcon(img.getImage().getScaledInstance(getWidth() - 300, getHeight(), Image.SCALE_SMOOTH));
		
		accessImg = new ImageIcon(getClass().getResource(f.accessibilityViewURL));
		accessImg = new ImageIcon(accessImg.getImage().getScaledInstance(getWidth() - 300, getHeight(), Image.SCALE_SMOOTH));
		
		washroomImg =  new ImageIcon(getClass().getResource(f.washroomViewURL));
		washroomImg = new ImageIcon(washroomImg.getImage().getScaledInstance(getWidth() - 300, getHeight(), Image.SCALE_SMOOTH));
		
		plainImg = new ImageIcon(getClass().getResource(f.blankViewURL));
		plainImg = new ImageIcon(plainImg.getImage().getScaledInstance(getWidth() - 300, getHeight(), Image.SCALE_SMOOTH));
		
		floorMap = new JLabel(img, JLabel.CENTER);
		
		pin = new ImageIcon(getClass().getResource("/other/pin.png"));
		pin = new ImageIcon(pin.getImage().getScaledInstance(25, 25, Image.SCALE_SMOOTH));
		pinLabel = new JLabel(pin, JLabel.CENTER);
		
		
		background.setBounds(0, 0, getWidth(), getHeight());
		
		backButton.addActionListener(this);
		backButton.setBounds(20, 20, 120, 40);
		backButton.setBackground(Color.yellow);
		
	    zoomInButton.addActionListener(this);
	    zoomInButton.setBounds(60, 65, 40, 40);
		
		zoomOutButton.addActionListener(this);
		zoomOutButton.setBounds(60, 110, 40, 40);
		 
		listPOIsButton.addActionListener(this);
		listPOIsButton.setBounds(getWidth() - 140, 150, 120, 40);
		
		createPOIButton.addActionListener(this);
		createPOIButton.setBounds(getWidth() - 140, 200, 140, 40);
		createPOIButton.setVisible(false);
		
		addToFavButton.addActionListener(this);
		addToFavButton.setBackground(Color.yellow);
		addToFavButton.setBounds(getWidth() - 140, 250 , 140, 40);
		addToFavButton.setVisible(false);
		
		/*
		 * Initializing Custom POI form components
		 */
		enterCustomInfoPanel.setBounds(120, 50, 400, 400);
		enterCustomInfoPanel.setLayout(null);
		enterCustomInfoPanel.setVisible(false);
		customNameLabel.setBounds(50, 50, 80, 40);
		customNameField.setBounds(50, 100, 200, 40);
		customDescriptionLabel.setBounds(50, 170 , 80, 40);
		customDescriptionField.setBounds(50, 200, 200, 100);
		
		submitCustomButton.addActionListener(this);
		submitCustomButton.setBounds(150, 350, 150 , 40);
		closeAddCustomButton.addActionListener(this);
		closeAddCustomButton.setBounds(0, 0, 70, 40);
		
		enterCustomInfoPanel.add(customNameLabel);
		enterCustomInfoPanel.add(customNameField);
		enterCustomInfoPanel.add(customDescriptionLabel);
		enterCustomInfoPanel.add(customDescriptionField);
		enterCustomInfoPanel.add(submitCustomButton);
		enterCustomInfoPanel.add(closeAddCustomButton);
		
		/*
		 * Initializing favourite form components
		 */
		enterFavInfoPanel.setBounds(120, 50, 400, 400);
		enterFavInfoPanel.setLayout(null);
		enterFavInfoPanel.setVisible(false);
		favPOINameLabel.setBounds(50, 50, 80, 40);
		favPOINameField.setBounds(50, 100, 200, 40);
		favPOIDescriptionField.setBounds(50, 200, 200, 100);
		favPOIDescriptionLabel.setBounds(50, 170 , 80, 40);
		
		submitFavButton.addActionListener(this);
		submitFavButton.setBounds(150, 350, 150 , 40);
		closeAddFavButton.addActionListener(this);
		closeAddFavButton.setBounds(0, 0, 70, 40);
		
		enterFavInfoPanel.add(favPOINameLabel);
		enterFavInfoPanel.add(favPOIDescriptionLabel);
		enterFavInfoPanel.add(favPOIDescriptionField);
		enterFavInfoPanel.add(favPOINameField);
		enterFavInfoPanel.add(submitFavButton);
		enterFavInfoPanel.add(closeAddFavButton);
		
		favAddedSuccessLabel.setBounds(30, 200, 150, 40);
		favAddedSuccessLabel.setForeground(Color.green);
		favAddedSuccessLabel.setVisible(false);
		
		customAddedSuccessLabel.setBounds(40, 250, 120, 40);
		customAddedSuccessLabel.setForeground(Color.green);
		customAddedSuccessLabel.setVisible(false);;
		
		poiOutputPanel.setBounds(140, 50, 400, 600);
		poiOutputPanel.setLayout(null);
		poiOutputPanel.setVisible(false);
		poiOutputLabel.setBounds(50, 50, 200, 350);
		closePoiOutputButton.setBounds(0, 0, 20, 20);
		closePoiOutputButton.addActionListener(this);
		
		poiOutputPanel.add(poiOutputLabel);
		poiOutputPanel.add(closePoiOutputButton);
		
		/*
		 * Get the text to get POI names and set it to poiOutputLabel
		 */
		
		String output = "";
		for (POI p :floor.POIs) {
			String str = "<html>" +  p.getName() + "<br>";
			output += str;
		}
		output+= "</html>";
		poiOutputLabel.setText(output);
		poiOutputPanel.add(poiOutputLabel);
		
		this.add(backButton);
		this.add(zoomInButton);
		this.add(zoomOutButton);
		this.add(viewChoice);
		this.add(listPOIsButton);
		this.add(createPOIButton);
		this.add(addToFavButton);
		this.add(enterFavInfoPanel);
		this.add(enterCustomInfoPanel);
		this.add(poiOutputPanel);
		this.add(favAddedSuccessLabel);
		
		background.add(floorMap);
		
		addPinActionListener(floorMap);
		
		this.add(background);
	}
	
	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub
		if (e.getSource() == backButton) {
			this.dispose();
			Main.BPAGE.setVisible(true);
		}
		if (e.getSource() == viewChoice) {
			int index = viewChoice.getSelectedIndex();
			if (index == 0) {
				//change map back to regular POI view
				floorMap.setIcon(img);
			} else if (index == 1){
				//change floorMap to accessibility view image
				floorMap.setIcon(accessImg);
			} else if (index == 2){
				//change floorMap to washroom view
				floorMap.setIcon(washroomImg);
			} else {
				//change floorMap to blank view
				floorMap.setIcon(plainImg);
			}
		}
		if (e.getSource() == addToFavButton) {
			//set the panel to be visible
			enterFavInfoPanel.setVisible(true);
			favAddedSuccessLabel.setVisible(false);
		}
		if (e.getSource() == closeAddFavButton) {
			//set the panel to be invisible
			enterFavInfoPanel.setVisible(false);
		}
		if (e.getSource() == submitFavButton) {
			//add point to the favourite list (write to JSON)
			String POIname = favPOINameField.getText();
			String POIdesc = favPOIDescriptionField.getText();
			
			UserPOI p = new UserPOI(POIname, insideOf.buildingName, floor, true);
			
			p.setDescription(POIdesc);
			p.xCoordinate = pinPointX;
			p.yCoordinate = pinPointY;
			
			Favourite fav = UserData.getFavs(Main.CURRENTUSER);
			fav.mark(p, Main.CURRENTUSER);
			enterFavInfoPanel.setVisible(false);
			favAddedSuccessLabel.setVisible(true);
		}
		if (e.getSource() == createPOIButton) {
			//set the panel to be visible
			enterCustomInfoPanel.setVisible(true);
			customAddedSuccessLabel.setVisible(false);
		}
		if (e.getSource() == closeAddCustomButton){
			//set the panel to be invisible
			enterCustomInfoPanel.setVisible(false);
		}
		if (e.getSource() == submitCustomButton) {
			//Drop a purple pin where the custom POI was clicked, and add that point to POIs
			String POIname = customNameField.getText();
			String POIdesc = customDescriptionField.getText();
			
			
			UserPOI p = new UserPOI(POIname, insideOf.buildingName, floor, true);
			
			p.setDescription(POIdesc);
			p.xCoordinate = pinPointX;
			p.yCoordinate = pinPointY;
			
			UserPOI.addUserPOI(POIname, insideOf.buildingName , Main.CURRENTUSER);
			floor.POIs.add(p);
			customPOIPin = new ImageIcon(getClass().getResource("/other/purplePin.png"));
			customPOIPin = new ImageIcon(customPOIPin.getImage().getScaledInstance(30, 30, Image.SCALE_SMOOTH));
			purplePinLabel = new JLabel(customPOIPin, JLabel.CENTER);
			
			floorMap.add(purplePinLabel);
			enterCustomInfoPanel.setVisible(false);
			customAddedSuccessLabel.setVisible(true);
		}
		if (e.getSource() ==  listPOIsButton) {
			poiOutputPanel.setVisible(true);
		}
		if (e.getSource() == closePoiOutputButton) {
			poiOutputPanel.setVisible(false);
		}
	}
	
	/*
	 * Action listener which is added to the blueprint, if it is clicked,
	 * drop a red pin where the click happened
	 */
	public void addPinActionListener(JLabel label) {

		label.addMouseListener(new MouseAdapter() {
			@Override
			public void mousePressed(MouseEvent e) {
				pinPointX = e.getX();
				pinPointY = e.getY();
				isPinDropped = true;
				pinLabel.setBounds(pinPointX, pinPointY, 10, 20);
				floorMap.add(pinLabel);
				createPOIButton.setVisible(true);
				addToFavButton.setVisible(true);
			}
		});
	}

}
