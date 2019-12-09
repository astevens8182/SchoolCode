import java.util.ArrayList;
import java.util.PriorityQueue;
import java.text.DecimalFormat;

/**
 * a complex class that reliles heavily on the cther classes such as customer, gv arrival and gv event and gv departure
 *
 * @author (Alex Stevens)
 * @version (2017)
 */
public class MarketPlace
{
    /*** average time between customers ***/
    double avgTime;
    /*** average cashier service time ***/
    double avgCashierTime;
    /*** number of cashiers ***/
    int numCashiers;
    /*** if the check out area should be displayed ***/
    boolean checkoutArea;
    /*** for the current time in the simulation ***/
    double currentTime;
    /*** ArrayList for the wait time in line ***/
    ArrayList <Customer> waitTime ;
    /*** ArrayList for the cashiers ***/
    Customer [] cashiers ; 
    /*** priority queue for the gv event class ***/
    PriorityQueue <GVevent> events;
    /*** instaniate the gv random class ***/
    GVrandom rand = new GVrandom();
    /*** string to post results ***/
    String results;
    /*** final int for open time ***/
    private final int OPEN =600;
    /*** final int for close time ***/
    private final int CLOSE = 1080;
    /*** int for the total number of customers ***/
    int totalCustomer; 
    /*** int for the longest line holder ***/ 
    int longestLine;
    /*** double for the total time wiehgted in line ***/ 
    double totalWeightTime;
    /*** double for last departure in line ***/
    double lastDeparture;
    /*** double for longest wait time in line ***/ 
    double timeLongestLine;
    /********************************************************************************
     * initializes the varibles and the objects and sets the start varibles 
     */
    public MarketPlace(){
        numCashiers = 3;
        avgCashierTime = 6.6;
        avgTime = 2.5; 
        checkoutArea = false; 
        currentTime = OPEN;
        events = new PriorityQueue <GVevent> ();
        waitTime = new ArrayList <Customer> () ;
        cashiers =  new Customer [numCashiers];
        results = "";
        totalCustomer = 0;
        longestLine = 0;
        totalWeightTime = 0.0;
        lastDeparture = 0.0;
        timeLongestLine = 0.0;
    }

    /********************************************************
     * a method that returns the number of cashiers 
     */
    public int getNumCashiers (){
        return numCashiers;
    }

    /********************************************************
     * a method that returns the average time between customers
     */
    public double getArrivalTime(){
        return avgTime;
    }

    /******************************************************
     * a method that returns the average service time between cashiers 
     */
    public double getServiceTime(){
        return avgCashierTime;
    }

    /**************************************************
     * a method that returns the number of total customers
     */
    public int getNumCustomersServed(){
        return totalCustomer; 
    }

    /*************************************************
     * a method that returns the results string 
     */
    public String getReport (){
        return results; 
    }

    /*********************************************
     * a method that returns the longest line int
     */
    public int getLongestLineLength (){
        return longestLine;
    }

    /********************************************
     * a method that calculates the average wieght time for a customer
     */
    public double getAverageWaitTime (){
        return ( totalWeightTime / totalCustomer);
    }

    /**********************************************
     * set the instance varibles 
     * @param int num
     * @param double s
     * @param double a
     * @param boolean ck
     */
    public void setParameters (int num, double s, double a, boolean ck){

        numCashiers = num;
        cashiers =new  Customer [numCashiers];
        avgCashierTime = s;
        avgTime = a;
        checkoutArea = ck; 
    }

    /********************************************
     *  a method that simulates the customer getting into the line to check out
     */
    public void customerGetsInLine () {
        Customer c = new Customer(currentTime);
        waitTime.add(c);
        if(waitTime.size() > longestLine){
            longestLine = waitTime.size();
            timeLongestLine = currentTime; 
        }
        if(cashierAvailable() != -1){
            customerToCashier(cashierAvailable());
        }
        if( currentTime < CLOSE){
            GVarrival a = new GVarrival(this, randomFutureTime(avgTime));
            events.add(a);
        }

    }

    /******************************************************
     * a method that simulates the customer paying for thier items 
     * @param int num
     */
    public void customerPays (int num){
        System.out.println("test");
        if( waitTime.size() != 0){
            customerToCashier(num);
            lastDeparture = currentTime; 
        }
        else{
            cashiers[num] = null ; 
        }
    }

    /**********************************************************
     * a method that reset the apporaite vaibles to zero 
     */
    private void reset (){  
        events = new PriorityQueue <GVevent> ();
        waitTime = new ArrayList <Customer> () ;
        results = "";
        totalCustomer = 0;
        longestLine = 0;
        totalWeightTime = 0.0;
        lastDeparture = 0.0;
        timeLongestLine = 0.0;
        currentTime = OPEN;
    }

    /*******************************************************
     * a method that sees if there is an open cashier
     */
    private int cashierAvailable (){
        for( int i =0; i < cashiers.length; i++){

            if (cashiers[i] == null){
                return i;
            }

        }
        return -1;
    }

    /************************************************
     * a method that claculates the future time
     * @param double avg
     */
    private double randomFutureTime (double avg) {
        return currentTime + rand.nextPoisson(avg); 
    }

    /**********************************************
     * a method that is the customer at the cashier counter
     * @Param int num
     */
    private void customerToCashier ( int num) {
        cashiers[num] = waitTime.get(0);

        totalWeightTime +=  currentTime - waitTime.get(0).getArrivalTime();
        totalCustomer ++;
        waitTime.remove(0);
        double futureTime = randomFutureTime (avgCashierTime);
        GVevent nextEvent = new GVdeparture(this, futureTime, num); 
        events.add(nextEvent);
    }

    /***************************************************
     * a method that starts the complete simulation 
     */
    public void startSimulation () {
        reset();
        GVarrival  a = new GVarrival(this, OPEN);
        events.add(a);
        while( !events.isEmpty()){
                         System.out.println("before" +events.size());
            GVevent  e =  events.poll();
             System.out.println(events.size());
            currentTime = e.getTime();
            e.process();
            if(checkoutArea){
                showCheckoutArea();
            }

            System.out.println("Time"+currentTime);
        }
        System.out.println("longest" +longestLine);
        createReport();
    }

    /******************************************************
     * a method that shows the checkout area
     */
    private void showCheckoutArea (){
        String str ="";
        String wait= "";
        for( Customer c: cashiers){
            if( c == null){
                str += "-";
            }
            else{
                str += "C";
            }

        }
        for( Customer w: waitTime){
            wait += "*";
        }

        results += formatTime( currentTime) + " " + str + " " + wait + "\n";

    }

    /***********************************************************
     * creates the report for the GUI
     */
    public void createReport (){
                DecimalFormat format = new DecimalFormat("##.##");
        results += " SIMULATION PARAMETERS\n" + " Number of cashiers: " + numCashiers + "\n"+
        "Average arrival: " + avgTime + "\n" + "Average Service: " + avgCashierTime + "\n" + "\n"+
        "RESULTS\n" + "Average wieght time: " +   format.format(getAverageWaitTime()) + " mins" + "\n" + "Max line length: "+
        longestLine + " at " + formatTime(timeLongestLine) + "\n" + "Customer Served: " + totalCustomer + "\n"
        + "Last departure: " + formatTime(lastDeparture) ;

    }

    /***********************************************************
     * formats the time 
     * @param double mins
     */
    public String formatTime( double mins) {
        DecimalFormat format = new DecimalFormat("00");
        String time = "";
        if( mins < 60) {
            return "12:" + format.format((int)mins) +"am";
        }
        else if ( mins < 720 ){
            int hours = (int)mins / 60; 
              time =hours + ":"  + format.format((int)(mins - hours*60)) + "am";
        }
        else if (mins < 780 ) {
            time= "12:" +format.format((int)( mins - 720)) + "pm";
        }
        else{
            mins = mins - 720;
            int hours = (int)mins / 60 ;
            time= hours + ":" + format.format((int)(mins -hours * 60)) + "pm" ;
        }
        return time;
    }
}
