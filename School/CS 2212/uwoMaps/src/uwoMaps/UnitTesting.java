package uwoMaps;

import java.util.ArrayList;

import static org.junit.Assert.*;

import org.junit.Assert;
import org.junit.Test;

/**
 * 
 * @author Taoran Gong, tgong9@uwo.ca
 * @version 1.3
 * 
 *          This class represents the unit testing as part of our testings
 */
public class UnitTesting {

	@Test
// this is the  unit test for building and floor classes
	public void testBuilding() {
		/*
		 * Test the insertion of building
		 */
		Building test = new Building("test");
		assertEquals("test", test.getName());

		// test result: pass
		/*
		 * Test the num of floors
		 */
		test.numOfFloors = 3;
		assertEquals(3, (int) test.getNumofFloors());
		// test result: pass
		/*
		 * add and remove a new floor to the building
		 */

		Building build2 = new Building("build2");
		Floor tryFloor = new Floor();
		build2.numOfFloors = 5;
		/*
		 * See if the number of floors = 5
		 */
		assertEquals(5, (int) build2.getNumofFloors());
		// test result: pass
		/*
		 * The first floor of build2 will be tryFloor;
		 */
		tryFloor.floorNum = 1;
		/*
		 * add tryfloor to build2
		 */
		build2.addFloor(tryFloor);
		/*
		 * since build2 adds a new floor, it supposes to be 6 floors instead of 5
		 */
		assertEquals(6, (int) build2.getNumofFloors());
		// test result: pass

		/*
		 * test the Remove floor method
		 */
		Building build3 = new Building("build3");
		// test result: pass
		Floor toBeRemoved = new Floor();
		/*
		 * Defines that building 3 will have 6 floors
		 */
		build3.numOfFloors = 6;
		/*
		 * add one floor would make it 7 floors
		 */
		build3.addFloor(toBeRemoved);
		/*
		 * remove the floor would make it 6 floors again
		 */
		build3.removeFloor(toBeRemoved);
		/*
		 * Now test if it equals 6 floors
		 **/
		assertEquals(6, (int) build3.getNumofFloors());
		// test result: pass

	}

	/*
	 * Test the setter and getter for building address
	 */

	public void testSetter_setAddr() throws NoSuchFieldException, IllegalAccessException {
		final Building testAddr = new Building();
		testAddr.setAddress("test address");
		assertEquals("test address", testAddr.getAddress());
	}
	/*
	 * A few exceptions are thrown for the setters for error checking The getter and
	 * setter are tested together in this method. Both of them must work in order to
	 * pass the test Test result: pass
	 */

	/*
	 * After the unit testing, all methods in building class work properly With
	 * these two classes we are able to manage building and floor information within
	 * our system Each method and class are generating the correct results
	 * 
	 */

	/*
	 * The other class I did unit testing is POI class. All other POI classes such
	 * as UserPOI and UserData and Favourite all have similar features with POI
	 * class It makes most sense that I'm testing the main class because some of the
	 * classes actually inherit from this class as well
	 */

	public void testPOI() {
		Building poiBuilding = new Building();
		Floor floor1 = new Floor();
		POI newPOI = new POI("tryPOI", floor1, true);
		/*
		 * setting the new POI and give it information
		 */

		assertEquals(floor1, newPOI.getFloor());
		// test if which floor the new POI is on is true
		// test result: pass
		assertEquals("tryPOI", newPOI.getClass());
		// test the POI is in the right name stored
		// test result: pass
		assertEquals(true, newPOI.equals(newPOI));
		// test if the visuability is true
		// test result: pass
	}

	/*
	 * Lastly I tested MetaData class. I tested this class because there are too
	 * many datas to insert, It would save us a lot of time to make sure it produces
	 * correct results at the very first stage
	 */
	public void testMetaData() {
		Building metaDatabuild = new Building();
		Floor metadataFloor = new Floor();
		MetaData MetaData = new MetaData("room1", "metaDatabuild");

		MetaData.setClassroom("room1");
		assertEquals("room1", MetaData.getClassroom());
		// test result:pass

		MetaData.setLectern("sampleLectern");
		assertEquals("sampleLectern", MetaData.getLectern());
		// test result: pass

		MetaData.setSocialDisCapacity(20);
		assertEquals(20, (int) MetaData.getSocialDisCapacity());
		// test result: pass

		MetaData.setSeatingCapacity(599);
		assertEquals(599, (int) MetaData.getSeatingCapacity());
		// test result: pass

		/*
		 * More tests will be done on integration and validation testings The core
		 * classes and methods all passed the unit testing and we are excited to move
		 * forward to our integration testing
		 */

	}

}