import javax.swing.JOptionPane;
import java.util.Random;
import java.text.DecimalFormat;
/**
 * Write a description of class myPhone here.
 *
 * @author (Alex Stevens)
 * @version (a version number or a date)
 */
public class myPhone {
    private int numTexts;
    private double numDataAud;
    private double numDataVid;
    private double batLife;
    private String phoneNum;
    private String custName;
    private String sendText;
    private String readText;

    private double numMins;
    private int mins;
    private double chargeBattery;
    private boolean wiFiOn;
    private double audBat;
    private double vidBat;
    private static DecimalFormat fmt2 = new DecimalFormat("#.##");

    public myPhone() {

        numTexts = 0;
        numDataVid = 0.0;
        numDataAud = 0.0 ;
        batLife = 0.0;
        phoneNum = "";
        custName = "";

        chargeBattery=0.0;
        audBat = 0.0;
        vidBat= 0.0;

    }

    public myPhone(String name, String num) {
        custName ="Alex Stevens";
        phoneNum ="1234568790";

    }

    public int getnumTexts(){

        return numTexts;

    }



    public double getbatLife(){


            return batLife;

        }


    public double getDataUsage()
    {


        return (numDataVid + numDataAud);

    }

    public void chargeBattery(int mins){

        chargeBattery = ((double)mins / 120) + batLife;

        if (mins < 0 ){
            JOptionPane.showMessageDialog(null,"0.0 percent");
        }

        else if (mins <= 1.0){
            JOptionPane.showMessageDialog(null,"Battery Life" +  fmt2.format(chargeBattery));
        }
        else{
            JOptionPane.showMessageDialog(null, "Battery Life 1.0" );
            batLife += chargeBattery;

        }

        if (batLife > 1)
        batLife = 1;

    }

    public void setName(String n){
        custName = "Alex Stevens";

    }

    public void sendText(String n){
        sendText = "Hey Whats Up?";
        JOptionPane.showMessageDialog(null, "Hey Whats Up?");
        numTexts +=1;
    }

    public void readText(String n){
        int max = 4;
        int min = 0;
        int random = (int )(Math.random() * 4 + 0);
        String readText = "";
        if (random == 0)
            readText = "Nothing Much";
        else if (random == 1)
            readText = "Doing CIS homework";
        else if (random == 2)
            readText = " What do you think? Always coding!";
        else if (random == 3)
            readText = "Driving home from Work";
        else if (random == 4)
            readText = " Just got an A on my Project";

        JOptionPane.showMessageDialog(null,  readText);
    }

    public void streamVideo(int mins){
        //Data
        if(!wiFiOn){

            numDataVid += ((mins * 0.25) / 60);
        }
        else{
            numDataVid = 0;
        }
        //batery
        vidBat = ((double)mins / 360);
        if(mins <0){
            JOptionPane.showMessageDialog(null, "Cannot Have a Negitve number of Minutes");
        }
        if (mins> 360){
            JOptionPane.showMessageDialog(null, "Battery Low, please Charge");


        }
        if (batLife - vidBat < 0){
            JOptionPane.showMessageDialog(null, "Battery Low, please Charge");
        }

        else{

            JOptionPane.showMessageDialog(null,  "Battery Video  "+  fmt2.format(batLife - vidBat));
        }
    }

    public void streamAudio(int mins){
        //Data
        if (!wiFiOn){
            numDataAud += ((mins * 0.065) / 60);
        }
        else {
            numDataAud = 0;
        }

        // Battery
        audBat = ((double)mins / 720);
        if (mins <0){
            JOptionPane.showMessageDialog(null, "Cannot have a negitve number of minutes") ;

        }
        if(mins>720){
            JOptionPane.showMessageDialog(null, "Battery Low, please Charge");

        }
        //if (batLife - audBat < 0){
            JOptionPane.showMessageDialog(null, "Battery Low, please Charge");
        //}
        //else{
            JOptionPane.showMessageDialog(null, fmt2.format(batLife - audBat));
        //}
    }

    public void setWiFi(boolean wifi){
        this.wiFiOn = wifi;

    }

    public void setphoneNumber(String n){
        phoneNum = "1234567890";
    }

    private void startNewMonth(){
        numDataAud=0;
        numDataVid=0;

        numTexts = 0;
    }

    private double calcAdditionalDataFee(){
        double temptotalData = getDataUsage();
        double dataFee = 0.0;

        if (temptotalData >2){
            temptotalData -= 2;
            dataFee = Math.ceil(temptotalData) *15.00;

        }
        return dataFee;
    }

    private String fmtphoneNumber(){
        phoneNum = "(" + phoneNum.substring(0, 3) + ")" + phoneNum.substring(3, 6) + "-" +phoneNum.substring(6, 10);
        return phoneNum;
    }

    private double calcUsageCharge(){
        double usageCharge=0.0;
        usageCharge = (50 + calcAdditionalDataFee()) * 0.03;
        return usageCharge;

    }

    private double calcTotalFee(){
        double totalFee= 0.0;
        totalFee= calcAdditionalDataFee() + calcUsageCharge() + 0.61 + 50;

        return totalFee;

    }
    public static void main() {

  myPhone mine = new myPhone("Project 2 Demo", "1234567890");

  mine.chargeBattery(500);

  mine.setWiFi(false);

  mine.streamAudio(120);

  mine.streamVideo(120);

  mine.sendText("Project 2 Demo");

  mine.readText("Message");

  mine.printStatement();

   System.out.println(mine.getbatLife());

}
   public static void main(String [] args){

        myPhone mine = new myPhone("Alex Stevens", "123456790");
        mine.sendText("Message");
        mine.readText("Message");
        mine.getbatLife();
        mine.chargeBattery(100);
        mine.streamVideo(40);
        mine.setWiFi(false);
        mine.streamVideo(300);
        mine.chargeBattery(100);
        mine.streamAudio(300);
        mine.chargeBattery(100);
        mine.setWiFi(true);
        mine.streamVideo(300);
        mine.chargeBattery(100);
        mine.setWiFi(false);
        mine.streamVideo(300);
        mine.chargeBattery(100);
        mine.streamVideo(50);
        mine.chargeBattery(100);
        mine.streamAudio(250);
        mine.chargeBattery(200);
        mine.getDataUsage();
        mine.readText("Message");

        mine.printStatement();

    }
    public void  printStatement(){
        System.out.println("Monthly Phone Bill");
        System.out.println("Customer:     "  + custName);
        System.out.println("Number:       "  + fmtphoneNumber());
        System.out.println("Texts:        " +  numTexts);
        System.out.println("Data usage:   " + fmt2.format(getDataUsage()) + "GB");
        System.out.println("     ");
        System.out.println("      ");
        System.out.println("2GB Plan                  " + "$50.00");
        System.out.println("Additional data fee:      " + "$" + calcAdditionalDataFee());
        System.out.println("Universal Usage (3%):     " + "$" +calcUsageCharge());
        System.out.println("Administrative Fee        " + "$0.61");
        System.out.println("Total Charges:            " + "$" +calcTotalFee());

    }
}
