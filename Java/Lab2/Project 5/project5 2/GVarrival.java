
/**
GVarrival that extends GVevent.   

 *
 * @author (Alex Stevens)
 * @version (2017)
 */
public class GVarrival extends GVevent
{
    /******************************************************************
     *  invoke the base class constructor to set the MarketPlace object and the event time. 
     *  @param marketplace store and double time
     */
    public GVarrival (MarketPlace store, double time) {
        super(store, time); 
    }

    /********************************************************************
     * use the MarketPlace object in the base class to invoke customerGetsInLine(). 
     * @param 
     */
    public void process (){
        store.customerGetsInLine();
    }
}
