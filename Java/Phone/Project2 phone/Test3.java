
/**
 * test3.
 *
 * @author (Alex Stevens)
 * @version (2017)
 */
public class Test3
{
       public static void main(String args[]){
        MyPhone yours = new MyPhone("Henry Hall", "5555555555");
        for(int i=1; i <= 6; i++){
            yours.chargeBattery(120);   
            yours.streamAudio(700);
        } 

        for(int i=1; i <= 3; i++){
              yours.sendText("Message");
        } 
        
        yours.printStatement();
    } 

}
