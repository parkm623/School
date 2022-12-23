package uwoMaps;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;

/**
 * 
 * @author david alter dalter4@uwo.ca
 * @version 1.7
 * @since 1.0
 * 
 * This class represents the Building page which is based on which building you clicked, 
 * You can click on the suide buttons to navigate to a floor in the building
 * 
 * <p>
 * This class is set up dynamically so it will open the correct number of buttons to the 
 * correct number of floors in the building
 * <p>
 */


public class BuildingPage extends JFrame implements ActionListener{
	
	Building building = new Building();
	
	int numFloors;
	
	JButton backButton = new JButton("<");
	private ImageIcon img;
	private JPanel background = new JPanel();
	
	ArrayList<JButton> floorButtons;
	
	public BuildingPage(Building build){
		Main.CMAP.setVisible(false);
		Main.BPAGE = this;
		
		building = build;
		numFloors = build.numOfFloors;
		
		Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
		
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLayout(null);
		this.setSize(screenSize);
		this.setVisible(true);
		this.setLocationRelativeTo(null);
		this.setTitle(build.buildingName);
		
		img = new ImageIcon(getClass().getResource(build.imageURL));
		img = new ImageIcon(img.getImage().getScaledInstance(getWidth() - 100, getHeight(), Image.SCALE_SMOOTH));
		JLabel label = new JLabel(img, JLabel.CENTER);
		background.add(label);
		
		floorButtons = new ArrayList<JButton>();
		
		
		int heightOfButton = 0;
		for (int i = 1; i < build.numOfFloors + 1; i++) {
			JButton button = new JButton();
			button.setText(String.valueOf(i));
			button.setName(String.valueOf(i));
			button.addActionListener(this);
			button.setBounds(getWidth() - 45, getHeight() - 80 - heightOfButton, 40, 40);
			button.setBackground(Color.YELLOW);
			button.setVisible(true);
			this.add(button);
			heightOfButton += 40;
			floorButtons.add(button);
		}
		
		background.setBounds(0, 0, getWidth(), getHeight());
		backButton.addActionListener(this);
		backButton.setBounds(0, 0, 40, 40);
		backButton.setBackground(Color.yellow);
		
		this.add(backButton);
		this.add(background);
		
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub
		if (e.getSource() == backButton) {
			this.dispose();
			Main.CMAP.setVisible(true);
		}
		if (floorButtons.contains(e.getSource())) {
			int index = Integer.parseInt(((JButton)e.getSource()).getName()) - 1;
			Floor f = building.floors.get(index);
			FloorPage fp = new FloorPage(building, f);
		}
	}
	

}
