
/**
 * Implement a Customer class to maintain the time the customer arrived in line (double).
.
 *
 * @author (Alex Stevens)
 * @version (Stevens)
 */
public class Customer
{
    double time; 
    /***************************************************************************
     * – initialize the instance variable
     * @param double time
     */
    public Customer (double time){
        this.time = time;
    }

    /*****************************************************************************
     * set the instacne varible
     * @param double t
     */
    public void setArrivalTime (double t) {
        time = t;
    }

    /******************************************************************************
     * return the arrival time
     * @param time
     */
    public double getArrivalTime () {
        return time;
    }
    /*******************************************************************************
     * main method used for testing 
     */
    public static void main  (String [] args) {
        Customer c = new Customer(2.0);
        c.setArrivalTime(2.0);
        c.getArrivalTime();
        System.out.println(c.getArrivalTime());
        
        
    }
}
