
/**
 * this class is used to tell the market place class if someone is leaving and it extends the gv event class
 *
 * @author (Alex Stevens)
 * @version (2017)
 */
public class GVdeparture extends GVevent{
    /***********************************************************
     * invokes the base class constructor to set the marketplace object, the event time and cashier id
     * @param marketplace store
     * @param double time
     * @param int id
     */
    public GVdeparture (MarketPlace store, double time, int id){
        super(store, time, id);
    }
    /*********************************************************
     * uses the marketplace object in the base class to invoke the customerpays
     */
    public void process (){
        // need to change int
        store.customerPays(getCashier());
    } 
}
