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

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

import uwoMaps.Building;

public class FloorPage extends JFrame implements ActionListener{
	
	Building insideOf;
	Floor floor;
	
	boolean isPinDropped; 
	int pinPointX;
	int pinPointY;
	
	private ImageIcon img;
	private ImageIcon accessImg;
	private ImageIcon washroomImg;
	private ImageIcon plainImg;
	private ImageIcon pin;
	private JLabel pinLabel;
	private JLabel floorMap;
	private JPanel background = new JPanel();
	
	private JPanel enterFavInfoPanel = new JPanel();
	private JPanel enterCustomInfoPanel = new JPanel();
	
	private JLabel favAddedSuccessLabel = new JLabel("POI added to Favourites");
	private JLabel customAddedSuccessLabel = new JLabel("New Custom POI added");
	
	JButton backButton = new JButton("Go back");
	JButton closeAddFavButton = new JButton("Cancel");
	JButton closeAddCustomButton = new JButton("Cancel");
	JButton zoomInButton = new JButton("+");
	JButton zoomOutButton= new JButton("-");
	
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
	JComboBox viewChoice; 
	

	public FloorPage(Building build, Floor f) {
		Main.BPAGE.setVisible(false);
		insideOf = build;
		floor = f;
		isPinDropped = false;
		
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
		
		favAddedSuccessLabel.setBounds(40, 200, 120, 40);
		favAddedSuccessLabel.setForeground(Color.green);
		favAddedSuccessLabel.setVisible(false);
		
		customAddedSuccessLabel.setBounds(40, 250, 120, 40);
		customAddedSuccessLabel.setForeground(Color.green);
		customAddedSuccessLabel.setVisible(false);;
		
		this.add(backButton);
		this.add(zoomInButton);
		this.add(zoomOutButton);
		this.add(viewChoice);
		this.add(listPOIsButton);
		this.add(createPOIButton);
		this.add(addToFavButton);
		this.add(enterFavInfoPanel);
		this.add(enterCustomInfoPanel);
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
			enterFavInfoPanel.setVisible(true);
		}
		if (e.getSource() == closeAddFavButton) {
			enterFavInfoPanel.setVisible(false);
		}
		if (e.getSource() == submitFavButton) {
			
			String POIname = favPOINameField.getText();
			String POIdesc = favPOIDescriptionField.getText();
			
			UserPOI p = new UserPOI(POIname, insideOf.buildingName, floor, true);
			
			p.setDescription(POIdesc);
			p.xCoordinate = pinPointX;
			p.yCoordinate = pinPointY;
			
			//favourites is Main.users.getFavs(Main.CURRENTUSER)
			Favourite fav = Main.users.getFavs(Main.CURRENTUSER);
			fav.mark(p, Main.CURRENTUSER);
			enterFavInfoPanel.setVisible(false);
			favAddedSuccessLabel.setVisible(true);
		}
		if (e.getSource() == createPOIButton) {
			enterCustomInfoPanel.setVisible(true);
		}
		if (e.getSource() == closeAddCustomButton){
			enterCustomInfoPanel.setVisible(false);
		}
		if (e.getSource() == submitCustomButton) {
			String POIname = customNameField.getText();
			String POIdesc = customDescriptionField.getText();
			
			UserPOI p = new UserPOI(POIname, insideOf.buildingName, floor, true);
			
			p.setDescription(POIdesc);
			p.xCoordinate = pinPointX;
			p.yCoordinate = pinPointY;
			
		}
	}
	
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
