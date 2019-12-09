import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
import java.util.*;
import java.text.*;
import java.io.*;

/*************************************************************
 * GUI for a Baby Name Database
 * 
 * @author Scott Grissom
 * @version October 7, 2017
 ************************************************************/
public class BabyNameGUI extends JFrame implements ActionListener{

    // FIX ME: Define a BabyNameDatabase variable
    private BabyNamesDatabase babyData;
    // FIX ME: Define buttons
    /** buttons**/
    private JButton byYear;
    private JButton mostPopular;
    private JButton topTen;
    private JButton byName;
    // FIX ME: Define text fields
    /** text fields**/
    private JTextField yearTxt;
    private JTextField nameTxt;

    /** Results text area */
    JTextArea resultsArea;

    /** menu items */
    JMenuBar menus;
    JMenu fileMenu;
    JMenuItem quitItem;
    JMenuItem openItem;
    JMenuItem countItem;

    /*****************************************************************
     * Main Method
     ****************************************************************/ 
    public static void main(String args[]){
        BabyNameGUI gui = new BabyNameGUI();
        gui.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        gui.setTitle("Baby Names");
        gui.pack();
        gui.setVisible(true);
    }

    /*****************************************************************
     * constructor installs all of the GUI components
     ****************************************************************/    
    public BabyNameGUI(){

        // FIX ME: instantiate an object of type BabyNameDatbase  
        babyData = new BabyNamesDatabase();
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
        add(new JLabel("Searches"), loc);

        // FIX ME: create labels, textfields and buttons 
        loc.gridx = 1;
        loc.gridy = 6;
        add(new JLabel ("Year"), loc);
        loc.gridx = 2;
        loc.gridy = 6;
        yearTxt = new JTextField(4);
        add(yearTxt , loc);
        // by year button
        loc.gridx = 2;
        loc.gridy = 7;
        byYear= new JButton("By Year");
        add(byYear, loc);
        // most popluar button
        loc.gridx = 2;
        loc.gridy = 8;
        mostPopular= new JButton("Most Popular");
        add(mostPopular, loc);
        // top ten button
        loc.gridx = 2;
        loc.gridy = 9;
        topTen= new JButton("Top Ten");
        add(topTen, loc);
        // name text field
        loc.gridx = 1;
        loc.gridy = 10;
        add(new JLabel ("Name"), loc);
        loc.gridx = 2;
        loc.gridy = 10;
        nameTxt = new JTextField(10);
        add(nameTxt , loc);
        //name button
        loc.gridx = 3;
        loc.gridy = 10;
        byName= new JButton("By Name");
        add(byName, loc);
        // FIX ME: register listeners for the buttons
        byName.addActionListener(this);
        byYear.addActionListener(this);
        mostPopular.addActionListener(this);
        topTen.addActionListener(this);
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
        if (buttonPressed == openItem){
            openFile();
        }  
        else if (buttonPressed == quitItem){
            System.exit(1);
        }
        else if (buttonPressed == topTen){
            displayTopTen();
        }
        else if (buttonPressed == mostPopular){
            displayMostPopular();
        }
        else if (buttonPressed == byYear){
            displayByYear();
        }
        else if (buttonPressed == byName){
            displayByName();
        }
        else if (buttonPressed == countItem){
            displayCounts ();
        }
    }

    /****************************************************************
     * private helper method that is used by the action performed class
     * @param list
     */
    private void displayNames (ArrayList <BabyName> list){
        int temp = 0;
        resultsArea.setText("");
        for(BabyName b: list){
            resultsArea.append("\n" + b.toString()+b.getBabyName());
            
        }
        list.size();
    }

    /****************************************************************
     * private helper method that displays the most popular names.
     * @year / text field
     */
    private void displayMostPopular(){
                resultsArea.setText("");
        mostPopular.setText("");
        String str = yearTxt.getText();
        int year = Integer.parseInt(str);
        babyData.mostPopularGirl(year);
        babyData.mostPopularBoy(year);
         resultsArea.append("\n" +babyData.mostPopularBoy(year).toString());
        resultsArea.append("\n" +babyData.mostPopularGirl(year).toString());
       
    }

    /****************************************************************
     * private helper method that displays the names  by year .
     * @year / text field
     */
    private void displayByYear(){
                resultsArea.setText("");
        byYear.setText("");
         String str = yearTxt.getText();
        int year = Integer.parseInt(str);
        resultsArea.append("\n" +babyData.searchForYear(year).toString());
        
        
    }

    /******************************************************************
     * private helper method that displays the top ten baby names
     * @param count
     */   
    private void displayTopTen (){
                 resultsArea.setText("");
        byYear.setText("");
         String str = yearTxt.getText();
        int year = Integer.parseInt(str);
        resultsArea.append("\n" + babyData.topTenNames(year).toString());
    }

    /******************************************************************
     * private helper method that displays the babies by name
     * @param name
     */
    private void displayByName (){
               resultsArea.setText("");
        byName.setText("");
        
        String str = nameTxt.getText();
        babyData.searchForName(str);
        resultsArea.append("\n" + babyData.searchForName(str));
        
    }

    /*****************************************************************
     * private helper method that displays the babies by count
     * @param count
     */
    private void displayCounts (){
        resultsArea.setText("");
        
            resultsArea.append("\n" + "Boys: " + babyData.countAllBoys());
            resultsArea.append("\n" + "Gris: " + babyData.countAllGirls());  
        }
    
    

    /*****************************************************************
     * open a data file with the name selected by the user
     ****************************************************************/ 
    private void openFile(){

        // create File Chooser so that it starts at the current directory
        String userDir = System.getProperty("user.dir");
        JFileChooser fc = new JFileChooser(userDir);

        // show File Chooser and wait for user selection
        int returnVal = fc.showOpenDialog(this);

        // did the user select a file?
        if (returnVal == JFileChooser.APPROVE_OPTION) {
            String filename = fc.getSelectedFile().getName();

            // FIX ME: change the following line as needed

            // to use your instance variable name
            babyData.readBabyNameData(filename);          
        }
    }

    /*******************************************************
    Creates the menu items
     *******************************************************/    
    private void setupMenus(){
        fileMenu = new JMenu("File");
        quitItem = new JMenuItem("Quit");
        countItem = new JMenuItem("Counts");
        openItem = new JMenuItem("Open...");
        fileMenu.add(countItem);
        fileMenu.add(openItem);
        fileMenu.add(quitItem);
        menus = new JMenuBar();
        setJMenuBar(menus);
        menus.add(fileMenu);

        // FIX ME: register the menu items with the action listener
        quitItem.addActionListener(this);
        countItem.addActionListener(this);
        openItem.addActionListener(this);

    }
}