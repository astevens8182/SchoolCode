
/**
 * Write a description of class MarketTest here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class MarketTest
{
       public static void main(String args[]){
        System.out.println("Start testing...");
        
        // does store start with 3 cashiers?
        MarketPlace myStore = new MarketPlace();
        assert(myStore.getNumCashiers() == 3) : "Start with 3 cashiers";

        // how many customers served with default arrival time
        myStore.startSimulation();
        int before = myStore.getNumCustomersServed();
             
        // are parameters updated correctly?
        myStore.setParameters(2, 4, 2, false);
        assert(myStore.getNumCashiers() == 2) : "Change to 2 cashiers";

        // how many customers served with quicker arrival times?
        myStore.startSimulation();
        int after = myStore.getNumCustomersServed();
        assert(before < after) : "Should be more customers";
        
        System.out.println("Testing complete.");
    }

}
