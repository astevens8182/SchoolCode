

import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

    import java.util.ArrayList;
/**
 * A baby Test class that test all the baby methods 
 *
 * @author (Alex STevens)
 * @version (2017)
 */
public class BabyTest
{
public static void main(String args[]){
	BabyNamesDatabase db = new BabyNamesDatabase();

	// read small data file created just for testing
	db.readBabyNameData("test.rtf");

	// check number of records
	if(db.countAllNames() != 6){
		System.out.println("Error: Number of names should be 6");
	}
		
	// check most popular boy
	BabyName popular = db.mostPopularBoy(1999);
	String name = popular.getBabyName();
	if(name.equals("Scott") == false){
		System.out.println("Error: Popular boy in 1999 should be Scott");
	}
	// check number of records for one year
	ArrayList<BabyName> tempList = db.searchForYear(1999);

	if(tempList.size() != 4){
		System.out.println("Error: Should be 4 records in 1999");
	}

	System.out.println("Scanning complete.");
}
}


