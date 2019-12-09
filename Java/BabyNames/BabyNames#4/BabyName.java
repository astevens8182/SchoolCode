import java.lang.Comparable;
/**
 * A class that sort the read in file baby names into things we can use in the GUI
 *
 * @author (Alex Stevens)
 * @version (2017)
 */
public class BabyName implements Comparable{

    /*** A String that holds the baby name***/
    private String name;
    /*** A boolean that holds the gender***/
    private boolean isFemale;
    /*** An int that holds the number of babies***/
    private int num;
    /*** An int that holds the babies birth year**/
    private int year;
    /***************************************************************
     * A constructor method that intilizes the instance varibles set above
     * @param none
     */
    public BabyName (String n, boolean g, int count, int yr){
        name = n; 
        isFemale = g;
        num = count;
        year = yr;
    }

    /***************************************************************
     * This method Allows two babyname objects to be compared to with respect to number of births
     * @param object other
     */
    public int compareTo (Object other){
        BabyName b = (BabyName) other;
        return (b.num - num);
    }

    /****************************************************************
     * returns true if a girl.  Otherwise, return false.
     * 
     * @Param true or false
     */
    public boolean isFemale(){
      boolean male = false;
      boolean female = true;
        if(isFemale )
            return   true  ;
        else 
            return  false; 
    }
  
    
    /******************************************************************
     * A getter method that returns the baby name
     * @param name
     */
    public String getBabyName(){
        return name;
    }

    /******************************************************************
     * A getter method that returns the baby birth year
     * @param year;
     */
    public int getBabyYear(){
        return year;
    }

    /*****************************************************************
     * A getter method for the number of babies born
     * @param num
     */
    public int getBabiesBorn(){
        return num;
    }

    /*****************************************************************
     * A setter method  that sets the baby name
     * @param name
     */
    public void setBabyName(String n){
        name = n;
    }

    /******************************************************************
     * A setter method that sets the year of the brith 
     * @param year
     */
    public void setBabyYear(int yr){
        year = yr;
    }

    /*******************************************************************
     * A setter method that sets the number of babies born
     * @param num
     */
    public void setBabiesBorn(int count){
        num = count;
    }

    /********************************************************************
     * A mehtod that sets the varibles on how the file baby names is read in
     * @param String 
     */
    public String toString() {
        if (isFemale == true)
        return ( num + " " + "girls" + " " + "named "+ name + " in " + year);
        else
        return  ( num + " " + "boys" + " " + "named "+ name + " in " + year);
    }

    /*********************************************************************
     * A main method that test each method. 
     */
    public static void main(String [] args){
        BabyName b = new BabyName("Bob", false , 5, 1994);
        b.setBabiesBorn(120);
        b.setBabyYear(1990);
        b.setBabyName("Alex");
        System.out.println(b.getBabiesBorn());
        System.out.println(b.getBabyYear()); 
        System.out.println(b.getBabyName());
        if(b.isFemale())
            System.out.println("female");
        else
            System.out.println("male");


    }
}
