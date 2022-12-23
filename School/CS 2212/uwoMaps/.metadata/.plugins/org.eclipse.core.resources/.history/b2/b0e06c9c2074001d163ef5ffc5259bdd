package uwoMaps;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;

public class FavouritesPage extends JFrame implements ActionListener{
	
	JButton backButton = new JButton("Go Back");
	
	Favourite fav;
	String userName = Main.MFRAME.user;
	
	public FavouritesPage(){
		
		Main.MFRAME.setVisible(false);
		
		fav = Main.loginFRAME.userdata.getFavs(userName);
		
		backButton.setBounds(0, 0, 120, 40);
		backButton.addActionListener(this);
		
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setLayout(null);
		this.setSize(700,500);
		this.setVisible(true);
		this.setTitle("My Favourites");
		
		
		this.add(backButton);
	}
	

	@Override
	public void actionPerformed(ActionEvent e) {
		// TODO Auto-generated method stub
		if (e.getSource() == backButton) {
			Main.MFRAME.setVisible(true);
	        this.dispose();
		}
	}

}
