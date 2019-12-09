
/**
 * test 2 .
 *
 * @author (Alex Stevens)
 * @version (2017)
 */
public class Test2
{
    public static void main(String args[]){
        MyPhone yours = new MyPhone("Henry Hall", "5555555555");
        yours.chargeBattery(120);   
        yours.streamAudio(700);
        yours.chargeBattery(120);   
        yours.streamAudio(700);
        yours.chargeBattery(120);   
        yours.streamAudio(700);        
        yours.printStatement();
    }  


}
