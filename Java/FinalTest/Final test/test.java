
/**
 * Write a description of class test here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class test
{
   public double paintOrder (int sqft){
       double labor = 0.0;
       labor =  ((sqft/ 75.0) *15.0) ;
       //labor = labor * 15.0;
       double paint =0.0;
       if(sqft ==200){
       paint = (sqft *(18.5/200));
    }
    else if ( sqft >200){
       paint = (sqft-200);
       paint = 200 -paint;
       paint= (paint + 200) / 200;
       paint = paint *18.5;
    }
       
    else{
        paint = 18.5;
    }
              //System.out.println(paint + labor);
       return paint + labor;
       

    }
       
   public static void printX (int size){
       for(int j=1; j<=size;j++){
           for(int i=1;i<=size;i++){
               if(i==j || i==size-j+1)
               System.out.print("*");
               else
               System.out.print(" ");
            }
            System.out.println();
        }
               
    }
}
