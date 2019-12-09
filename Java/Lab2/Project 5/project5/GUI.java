import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
import java.util.*;
import java.text.*;
import java.io.*;

/*************************************************************
 * GUI for a marketplace class
 * 
 * @author Scott Grissom
 * @version October 7, 2017
 ************************************************************/
public class GUI extends JFrame implements ActionListener{

    private MarketPlace mp;
    // FIX ME: Define buttons
    /** buttons**/
    private JButton simulate;
    /**checkBox**/
    private JCheckBox display;
    // FIX ME: Define text fields
    /** text fields**/
    private JTextField cashierTxt;
    private JTextField arrivalTxt;
    private JTextField serviceTxt;
    /** label**/

    private JLabel serviceLabel;

    /** Results text area */
    JTextArea resultsArea;

    /** menu items */
    JMenuBar menus;
    JMenu fileMenu;
    JMenuItem quitItem;
    JMenuItem clearItem;

    /*****************************************************************
     * Main Method
     ****************************************************************/ 
    public static void main(String args[]){
        GUI gui = new GUI();
        gui.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        gui.setTitle("MarketPlace");
        gui.pack();
        gui.setVisible(true);
    }

    /*****************************************************************
     * constructor installs all of the GUI components
     ****************************************************************/    
    public GUI(){

        // FIX ME: instantiate an object of type BabyNameDatbase  
        mp = new MarketPlace();
        // set the layout to GridBag
        setLayout(new GridBagLayout());
        GridBagConstraints loc = new GridBagConstraints();

        // create results area to span one column and 10 rows
        resultsArea = new JTextArea(20,20);
        JScrollPane scrollPane = new JScrollPane(resultsArea);
        loc.gridx = 0;
        loc.gridy = 1;
        loc.gridheight = 10;  
        loc.insets.left = 20;
        loc.insets.right = 20;
        loc.insets.bottom = 20;
        add(scrollPane, loc);  

        // create Results label
        loc.insets = new Insets(0,20,0,0);
        loc.gridx = 0;
        loc.gridy = 0;
        loc.gridheight = 1;
        loc.gridwidth = 1;
        loc.anchor = GridBagConstraints.LINE_START;
        add(new JLabel("Results"), loc);

        // create Searches label
        loc.insets = new Insets(0,20,0,0);
        loc.gridx = 2;
        loc.gridy = 0;
        loc.gridheight = 1;
        loc.gridwidth = 1;
        loc.anchor = GridBagConstraints.LINE_START;
        add(new JLabel("Parameters"), loc);

        // FIX ME: create labels, textfields and buttons 
        loc.gridx = 1;
        loc.gridy = 6;
        add(new JLabel ("Cashiers"), loc);
        loc.gridx = 2;
        loc.gridy = 6;
        cashierTxt = new JTextField(4);
        add(cashierTxt , loc);

        loc.gridx = 1;
        loc.gridy = 7;
        add(new JLabel ("Arrival Time"), loc);
        loc.gridx = 2;
        loc.gridy = 7;
        arrivalTxt = new JTextField(4);
        add(arrivalTxt , loc);

        loc.gridx = 1;
        loc.gridy = 8;
        add(new JLabel ("Service Time"), loc);
        loc.gridx = 2;
        loc.gridy = 8;
        serviceTxt = new JTextField(4);
        add(serviceTxt , loc);
        // top ten button
        loc.gridx = 2;
        loc.gridy = 9;
        display= new JCheckBox("Display");
        add(display, loc);

        //name button
        loc.gridx = 2;
        loc.gridy = 10;
        simulate= new JButton("Simulate");
        add(simulate, loc);
        // FIX ME: register listeners for the buttons
        simulate.addActionListener(this);
        display.addActionListener(this);

        // hide details of creating menus
        setupMenus();
    }

    /*****************************************************************
     * This method is called when any button is clicked.  The proper
     * internal method is called as needed.
     * 
     * @param e the event that was fired
     ****************************************************************/       
    public void actionPerformed(ActionEvent e){

        // extract the button that was clicked
        JComponent buttonPressed = (JComponent) e.getSource();

        // Allow user to load baby names from a file    
        if (buttonPressed == clearItem){
            resultsArea.setText("");
        }  
        else if (buttonPressed == quitItem){
            System.exit(1);
        }
        else if (buttonPressed == simulate){
            int cashierTime = 0;
            double arrvial = 0.0;
            double serviceTime = 0.0;
            boolean valid = true; 
            if(isValidNumber(cashierTxt.getText())){
                cashierTime = Integer.parseInt(cashierTxt.getText());
            }
            else{
                valid = false;
                JOptionPane.showMessageDialog(null, "Enter number of cashiers"); 
            }
            if(isValidNumber(arrivalTxt.getText())){
                arrvial = Double.parseDouble(arrivalTxt.getText());
            }
            else{
                valid = false;
                JOptionPane.showMessageDialog(null, "Enter average arrvail time");
            }
            if(isValidNumber(serviceTxt.getText())){
                serviceTime = Double.parseDouble(serviceTxt.getText());
            }
            else{
                valid = false;
                JOptionPane.showMessageDialog(null, "Enter average service time");
            }
            if(valid){
                
                mp.setParameters(cashierTime,serviceTime,arrvial, display.isSelected());
                mp.startSimulation();
                resultsArea.append(mp.getReport());
                
            }
        }
    }

    /****************************************************************
     * private helper method that is used by the action performed class
     * @param list
     */
    private boolean isValidNumber (String str){
        boolean isValid = true;
        try{
            Double.parseDouble(str);
        }catch ( Exception e){
            isValid = false;
        }
        return isValid;
    }

    


    

    /*******************************************************
    Creates the menu items
     *******************************************************/    
    private void setupMenus(){
        fileMenu = new JMenu("File");
        quitItem = new JMenuItem("Quit");

        clearItem = new JMenuItem("clear...");

        fileMenu.add(clearItem);
        fileMenu.add(quitItem);
        menus = new JMenuBar();
        setJMenuBar(menus);
        menus.add(fileMenu);

        // FIX ME: register the menu items with the action listener
        quitItem.addActionListener(this);
        clearItem.addActionListener(this);

    }
}
