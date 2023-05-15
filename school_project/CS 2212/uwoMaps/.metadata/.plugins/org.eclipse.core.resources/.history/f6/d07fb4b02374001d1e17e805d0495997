package uwoMaps;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.HashMap;

import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

/**
 * 
 * @author david alter dalter4@uwo.ca
 * @version 1.3
 * @since 1.0
 * 
 * This class represents a login page, the first frame you see when you start the 
 * application
 * 
 * <p>
 * From the LoginPage, if you log in with the correct credentials, you will be taken
 * to the home page, there is also an option for forget password on this page
 * <p>
 */
public class LoginPage extends JFrame implements ActionListener{
	
	//Save login info locally
	HashMap<String,String> loginInfo = new HashMap<String,String>();
	
	JButton signInButton = new JButton("Sign in");
	JButton forgotPasswordButton = new JButton("Forgot password?");
	
	JTextField userIDField = new JTextField();
	JPasswordField userPasswordField = new JPasswordField();
	
	JLabel idLabel = new JLabel("User ID:");
	JLabel passwordLabel = new JLabel("Password:");
	JLabel forgotPasswordLabel;
	JLabel loginResultLabel = new JLabel();
	
	public UserData userdata;
	
	
	LoginPage(HashMap<String,String> originalLoginInfo){
		
		loginInfo = originalLoginInfo;
		
		signInButton.setBounds(125, 320, 80, 40);
		signInButton.addActionListener(this);
		signInButton.setFont(new Font("Balgin", Font.PLAIN, 18));
		signInButton.setBackground(Color.cyan);
		signInButton.setBorder(BorderFactory.createEtchedBorder());
		
		forgotPasswordButton.setBounds(250, 320, 140, 40);
		forgotPasswordButton.addActionListener(this);
		forgotPasswordButton.setFont(new Font("Balgin", Font.PLAIN, 14));
		forgotPasswordButton.setBackground(Color.cyan);
		forgotPasswordButton.setBorder(BorderFactory.createEtchedBorder());
		
		idLabel.setBounds(50, 100, 75, 25);
		passwordLabel.setBounds(50, 150, 75, 25);
		
		userIDField.setBounds(125, 100, 250, 25);
		userPasswordField.setBounds(125, 150, 250, 25);
		
		loginResultLabel.setBounds(25, 25, 200, 30);
		loginResultLabel.setFont(new Font(null, Font.BOLD, 15));
		
		
		forgotPasswordLabel = new JLabel();
		forgotPasswordLabel.setText("Enter a new password: ");
		forgotPasswordLabel.setBounds(150,200,150,150);
		forgotPasswordLabel.setVisible(false);
		
		
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLayout(null);
		this.setSize(500,500);
		this.setVisible(true);
		this.setLocationRelativeTo(null);
		this.setTitle("Login");
		
		this.add(signInButton);
		this.add(forgotPasswordButton);
		this.add(idLabel);
		this.add(passwordLabel);
		this.add(userIDField);
		this.add(userPasswordField);
		this.add(loginResultLabel);

	}

	@Override
	public void actionPerformed(ActionEvent e) {
		
		if(e.getSource() == signInButton) {
			openHome();
		}
		
		if (e.getSource() == forgotPasswordButton) {
			forgotPasswordLabel.setVisible(true);
			openForgotPass();
			//prompt them to enter a different password
		}
		
	}
	
	public void openForgotPass(){
		//open new forgot password frame
		ForgotPasswordPage oFrm = new ForgotPasswordPage();
    }
	
	public void openHome() {
		String proposedUser = userIDField.getText();
		String proposedPassword = String.valueOf(userPasswordField.getPassword());
		//check if the password is correct for the username in the hashmap
		
		if (loginInfo.containsKey(proposedUser)) {
			if (loginInfo.get(proposedUser).equals(proposedPassword)) {
				//credentials are correct, proceed to ask if editing
				userdata = new UserData(proposedUser, proposedPassword);
				Main.CURRENTUSER = proposedUser;
				HomePage homePage = new HomePage(proposedUser);
			} else {
				//show incorrect password label if user is correct
				loginResultLabel.setForeground(Color.red);
				loginResultLabel.setText("Incorrect Password");
			}
		} else {
			//show no user found if user does not exist
			loginResultLabel.setForeground(Color.red);
			loginResultLabel.setText("No userId found");
		}
	}
}
