
import java.util.ArrayList;
import java.util.Scanner;
import java.io.File;
import java.io.IOException;
import java.text.NumberFormat;
import java.io.FileInputStream;
import java.lang.String;

import java.util.Collections;

/**
 *Maitains an unlimited number of baby names.
 *
 * @author (Alex Stevens)
 * @version (2017)
 */
public class BabyNamesDatabase
{
    ArrayList <BabyName> database;
    /******************************************************
     * a constructor that instantiate an empty ArrayList for the names
     */
    public BabyNamesDatabase (){
        database = new ArrayList<BabyName>();
    }

    /*******************************************************
     * a method that reads in the file for the baby names
     */
    public void readBabyNameData (String filename){
        // Read the full set of data from a text file
        try{ 

            // open the text file and use a Scanner to read the text
            FileInputStream fileByteStream = new FileInputStream(filename);
            Scanner scnr = new Scanner(fileByteStream);
            scnr.useDelimiter("[,\r\n]+");

            // keep reading as long as there is more data
            while(scnr.hasNext()) {

                // FIX ME: read the name, gender, count and year
                String name = scnr.next();
                String gender = scnr.next();
                int count = scnr.nextInt();
                int year = scnr.nextInt();

                // FIX ME: remove this print statement after method works
                

                // FIX ME: assign true/false to boolean isFemale based on
                // the gender String
                boolean isFemale = true;
                if( gender== "F"){
                    isFemale = true;
                }
                if( gender == "M"){
                    isFemale = false;
                }

                // FIX ME: instantiate a new Baby Name and add to ArrayList
                BabyName entry = new BabyName(name, isFemale, count, year); 
                database.add(entry);

            }
            fileByteStream.close();
        }
        catch(IOException e) {
            System.out.println("Failed to read the data file: " + filename);
        }
    }

    /************************************************************
     * a method that counts the total number of items in the array list
     * @returns int
     */
    public int countAllNames(){
        return database.size();
    }

    /**************************************************************
     *  A mehtod that counts all the girls that were born in the year 1880 until now
     *  @param count 
     */
    public int countAllGirls(){
        int temp = 0;
        for(BabyName b: database){
            while(b.isFemale()== true){
                temp += b.getBabiesBorn() + temp;
            }
        }
        return temp;
    }

    /**************************************************************
     *  A mehtod that counts all the boys that were born in the year 1880 until now
     *  @param count 
     */
    public int countAllBoys(){
        int count = 0;
        for(BabyName b: database){
            while(b.isFemale()== false){
                count += count;
            }
        }
        return count;
    }

    /************************************************************
     * Search the full list and return the most popular girl name for a specific year
     * @param int year
     */
    public BabyName mostPopularGirl (int year){
        BabyName highest= database.get(0);
        for(BabyName b : database){
            if(b.isFemale()  ){
                
                if(b.getBabiesBorn() > highest.getBabiesBorn()){
                    highest = b;
                    //return b.getBabyName();
                }
            
            }
        }
            
        
        return highest;
    }

    /************************************************************
     * Search the full list and return the most popular boy name for a specific year
     * @param int year
     */
    public BabyName mostPopularBoy (int year){
        BabyName highest= database.get(0);
        for(BabyName b : database){
            if(b.isFemale() ==false ){
                if(b.getBabiesBorn() > highest.getBabiesBorn()){
                    highest = b;
                }
            }

        }
        return highest;
    }

    /*****************************************************************
     * search the full list and return an array list of babies with the same name
     * @param name
     */
    public ArrayList <BabyName> searchForName (String name) {
        ArrayList<BabyName> matchList = new ArrayList();
        for(BabyName b: database){
            if(b.getBabyName().contains(name)){
                matchList.add(b);
            }
        }
        Collections.sort(matchList);
        return matchList; 

    }

    /*****************************************************************
     * Search the full Array and return an array list of babies born in that given year
     * @param year
     */
    public ArrayList <BabyName> searchForYear (int year){
        ArrayList <BabyName> yearList = new ArrayList();
        for(BabyName b: database){
            if(b.getBabyYear() == year){
                yearList.add(b);
            }
        }
        Collections.sort(yearList);
        return yearList; 
    }

    /*******************************************************************
     * return the top most popular baby names given a year
     * @param int year
     */
     public ArrayList <BabyName> topTenNames (int year){
        ArrayList <BabyName> topTenList = new ArrayList();
         for(BabyName b: database){
             for(int i=1; i<=10;i++){
                 topTenList.add(b);
                }
            }
            return topTenList; 
     }
}
