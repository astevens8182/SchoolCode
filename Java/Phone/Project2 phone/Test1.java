
/**
 * A test method that test all the function of the phone class
 *
 * @author (Alex Stevens)
 * @version (2017)
 */
public class Test1
{
       public static void main(String args[]){
        MyPhone mine = new MyPhone("Amanda Jaffe", "1234567890");
        MyPhone yours = new MyPhone("Henry Hall", "5555555555");
        mine.chargeBattery(120);   
        mine.streamAudio(360);
        mine.chargeBattery(30);   
        mine.streamAudio(530);
        mine.streamAudio(200);
        mine.sendText("message");
        mine.printStatement();
        mine.readText("l");
        yours.printStatement();
    }  

    
    
}
