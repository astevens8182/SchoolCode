import javax.swing.JOptionPane;
import java.util.Random;
import java.text.DecimalFormat; 
import java.text.NumberFormat;
/**
 * Does basic functions of a phone and makes a phone statment. 
 * @author (Alex Stevens)
 * @version (2017)
 */
public class MyPhone{
    /**integer for the number of texts**/
    private int numTexts;
    /**a double for the amount of  data **/
    private double numData;
    /**a double for the remaining battery life**/
    private double batLife;
    /**a string for the customers name**/
    private String custName;
    /**a String for the phone number**/
    private String phoneNum;
    /**final double for audio usage per minute**/
    private final double DATA_PER_MIN = 65 / 60.0;
    /**final double for the maximum of audio usage for a full battery charge**/
    private final double MAX_MINTUES = 720.0;
    /** format numbers into money format**/
    private static NumberFormat fmt = NumberFormat.getCurrencyInstance();
    /** formats decimals**/
    private static DecimalFormat fmt2 = new DecimalFormat("#.##");
    /************************************************
     * constructor method to initialize the varibles
     */
    public MyPhone (String n, String num){
        custName = n;
        phoneNum = num;
    }

    /************************************************
     * a getter method that returns the number of texts
     */
    public int getNumTexts (){
        return numTexts;
    }

    /************************************************
     * a getter method that returns a double for battery life
     */
    public double getBatteryLife (){
        return batLife;
    }

    /************************************************
     * a getter method that returns a double for the data usage
     */
    public double getDataUsage (){
        return numData;
    }

    /*************************************************
     * a setter method that sets the name of the customer
     */
    public void setName (String n){
        custName = n;
    }

    /*************************************************
     * a setter method that sets the customers number
     */
    public void setPhoneNumber (String n){
        phoneNum = n;
    }

    /************************************************
     * A method that streams audio and calcuates the data and battery used
     */
    public void streamAudio (int mins){
        double tempMax;
        tempMax = batLife * MAX_MINTUES;
        double tempData;

        //battery
        if(tempMax >= mins){
            numData +=  (DATA_PER_MIN * mins) / 1000;
        }
        if (tempMax < mins){
            numData += (DATA_PER_MIN * tempMax) / 1000;  
            JOptionPane.showMessageDialog(null, "battery low please charge");
        }
        if (mins < 0){
            JOptionPane.showMessageDialog(null, "Cannot have a negitive number of mins");
        }
        batLife = batLife - (mins / MAX_MINTUES);
    }

    /************************************************
     * a method that charges the battery
     */
    public void chargeBattery (int mins){
        batLife = ((double) mins / 120) + batLife;
        if (batLife < 0 ){
            JOptionPane.showMessageDialog(null,"0 Percent"); 
        }
        else if (batLife < 1.0){
            JOptionPane.showMessageDialog(null,"Battery Life " +  fmt2.format(batLife) + " Percent");
        }
        else{
            JOptionPane.showMessageDialog(null, "Battery Life 100 Percent" );
        }
        if (batLife > 1.0)
            batLife = 1.0;
    }

    /**************************************************
     * Method used to send  Text
     */
    public void sendText (String text){
        JOptionPane.showMessageDialog(null, text);
        numTexts += 1;
    }


    /**************************************************
     * method used to read texts
     */
    public void  readText (String text){
        int max = 4;
        int min = 0;
        int random = (int )(Math.random() * 4 + 0);
        String readText = "";
        switch (random){
            case 1:random = 0;
            readText = "Nothing Much";
            break;
            case 2:random = 1;
            readText = "Doing CIS homework";
            break;
            case 3: random = 2;
            readText = " What do you think? Always coding!";
            break;
            case 4:random = 3;
            readText = "Driving home from Work";
            break;
            case 5: random = 4;
            readText = " Just got an A on my Project";
            break;
        }
        JOptionPane.showMessageDialog(null, readText);
        numTexts +=1;
    }

    /**************************************************
     * a metheod that resets values to zero
     */
    private void startNewMonth (){
        numTexts = 0;
        numData = 0.0;
    }

    /**************************************************
     * a method that calculates addtional fees
     */
    private double calcAddtionalDataFee (){
        double temptotalData = getDataUsage();
        double dataFee = 0.0;

        if (temptotalData >2){
            temptotalData -= 2;
            dataFee = Math.ceil(temptotalData) *15.00;

        }
        return dataFee;
    }

    /**************************************************
     *  A method that calcualtes the usage charge
     */
    private double calcUsageCharge (){
        double usageCharge=0.0;
        usageCharge = (50 + calcAddtionalDataFee()) * 0.03;
        return usageCharge;
    }

    /***************************************************
     * calculate the total charges for the month
     */
    private double calcTotalFee (){
        double totalFee= 0.0;
        totalFee= calcAddtionalDataFee() + calcUsageCharge() + 0.61 + 50;
        return totalFee;
    }  

    /**************************************************
     *  formats the phone number 
     */
    private String fmtPhoneNumber (){

        phoneNum = "(" + phoneNum.substring(0, 3) + ")" + phoneNum.substring(3, 6) + "-" + phoneNum.substring(6, 10);
        return phoneNum;
    }

    /***************************************************
     * a print statment
     */
    public void printStatement(){
        System.out.println("MyPhone Monthly Statement");
        System.out.println("Customer:                " +custName);
        System.out.println("Number:                  " +fmtPhoneNumber());
        System.out.println("Texts:                   " + numTexts);
        System.out.println("Data usage:              " + fmt2.format(getDataUsage()) + "GB");
        System.out.println("2GB Plan:                " + "$50.00");
        System.out.println("Additional data fee:     "  + fmt.format(calcAddtionalDataFee()));
        System.out.println("Universal usage (3%)     " + fmt.format(calcUsageCharge()));
        System.out.println("Administrative Fee:      " + "$0.61");
        System.out.println("Total Charges:           " + fmt.format(calcTotalFee()));

    }

}
