package uwoMaps;

import java.awt.Color;
import java.awt.Desktop.Action;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.HashMap;

import javax.swing.AbstractAction;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;

/**
 * 
 * @author david alter dalter4@uwo.ca
 * @version 1.5
 * @since 1.0
 * 
 * This class represents the home page of the application, from here you can go to your
 * favourites, look at the weather for the day, or go to the Maop
 * 
 */

public class HomePage extends JFrame implements ActionListener{
	
	JButton signOutButton = new JButton();
	
	JButton goToMapButton = new JButton();
	JButton myFavouritesButton = new JButton();
	
	private ImageIcon weatherImg; 
	
	JLabel buildingsLabel = new JLabel("List of Buildings: ");
	JLabel favouritesLabel = new JLabel("Favourite POIs: ");
	JLabel weatherLabel = new JLabel("Today's weather: ");
	JLabel userLabel = new JLabel();
	JLabel minWeatherLabel = new JLabel();
	JLabel maxWeatherLabel = new JLabel();
	
	//save current user
	public String user;
	
	
	HomePage(String userId){
		
		Main.loginFRAME.setVisible(false);
		Main.MFRAME = this;
		
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLayout(null);
		this.setSize(700,500);
		this.setVisible(true);
		this.setLocationRelativeTo(null);
		this.setTitle("Uwo Maps Home");
		
		user = userId;
		
		buildingsLabel.setBounds(50,80,150,40);
		
		favouritesLabel.setBounds(50,280,150,40);
		
		
		weatherImg = new ImageIcon(getClass().getResource("/other/weatherLogo.png"));
		weatherImg = new ImageIcon(weatherImg.getImage().getScaledInstance(50, 50, Image.SCALE_SMOOTH));
		
		weatherLabel.setBounds(350, 280, 200, 40);
		weatherLabel.setIcon(weatherImg);

		minWeatherLabel.setBounds(350, 320, 200, 40);
		maxWeatherLabel.setBounds(350, 360, 200, 40);
		
		userLabel.setBounds(550, 0, 170, 40);
		userLabel.setText("Logged in as: " + userId);
		
		//retrieve weather from function
		double[] results = new double[2];
		try {
			results = Weather.getWeather();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		String minWeather = String.valueOf(results[0]);
		String maxWeather = String.valueOf(results[1]);
		
		minWeatherLabel.setText("Min temp today: " + minWeather + " °C");
		maxWeatherLabel.setText("Max temp today: " + maxWeather + " °C");
		
		signOutButton.addActionListener(this);
		signOutButton.setText("Sign Out");
		signOutButton.setBounds(0, 0, 120, 40);
	
		goToMapButton.addActionListener(this);
		goToMapButton.setText("Go to Map");
		goToMapButton.setBounds(50, 120, 100, 40);
		
		myFavouritesButton.addActionListener(this);
		myFavouritesButton.setText("Go to my favourites");
		myFavouritesButton.setBounds(50, 330, 160, 45);

		this.add(signOutButton);
		this.add(goToMapButton);
		this.add(myFavouritesButton);
		this.add(buildingsLabel);
		this.add(favouritesLabel);
		this.add(weatherLabel);
		this.add(minWeatherLabel);
		this.add(userLabel);
		this.add(maxWeatherLabel);
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		if (e.getSource() == signOutButton) {
			Main.loginFRAME.setVisible(true);
	        this.dispose();
		}
		if (e.getSource() == goToMapButton) {
			openCampusMap();
		}
		if (e.getSource() == myFavouritesButton) {
			openMyFavourites();
		}
		
	}
	
	public void openCampusMap(){
		CampusMap campusFrm = new CampusMap();
	}
	
	public void openMyFavourites() {
		FavouritesPage fp = new FavouritesPage();
	}
	
	public void openPOI(Building build, Floor f) {
		FloorPage fp = new FloorPage(build, f);
	}
	
}
