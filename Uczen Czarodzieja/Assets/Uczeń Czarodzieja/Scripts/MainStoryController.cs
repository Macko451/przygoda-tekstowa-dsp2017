using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainStoryController : MonoBehaviour 
{
	public Text gameText;

	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;

	void Start () 
	{
		gameText.text = "The Game Starts Now!";
		myState = States.cell;
	}
	

	void Update () 
	{
		
		switch (myState) 
		{
		case States.cell:
			state_cell ();
			break;
		case States.sheets_0:
			state_sheets_0 ();
			break;
		case States.mirror:
			state_mirror();
			break;
		case States.lock_0:
			state_lock_0();
			break;
		case States.cell_mirror:
			state_cell_mirror();
			break;
		case States.sheets_1:
			state_sheets_1();
			break;
		case States.lock_1:
			state_lock_1();
			break;
		case States.freedom:
			state_freedom ();
			break;
		default:
			gameText.text = "Something wrong.";
			break;
		}

	}

	void state_cell ()
	{
		gameText.text = "Sprawdzam tylko czy czcionki zawierają polskie znaki. Tylko takie znalazłem, które są dodatkowo w miarę pasujące.\n\n" +
						"Któraś Ci się podoba? ą ę ó ł ć ż ź ś";

		if (Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_0;} 
		else if (Input.GetKeyDown(KeyCode.M))	{myState = States.mirror;} 
		else if (Input.GetKeyDown(KeyCode.L))	{myState = States.lock_0;}
	}

	void state_sheets_0 ()
	{
		gameText.text = "There is just a bunch of dirty stuff, nothing interesting to look at.\n\n" +
						"Press R to return to cell.";

		if (Input.GetKeyDown(KeyCode.R))		{myState = States.cell;}
	}

	void state_lock_0 ()
	{
		gameText.text = "The doors are closed from the other side, there is nothing you can do about this at this moment. Perhaps something to take a look outside " + 
						"would be helpful?\n\n" +
						"Press R to return to cell.";

		if (Input.GetKeyDown(KeyCode.R))		{myState = States.cell;}
	}

	void state_mirror ()
	{
		gameText.text = "You can see yourself in the mirror. An old man with no chance to escape... Or maybe? This mirror seems to be useful to open the lock.\n\n" +
						"Press R to return to cell, T to take the mirror of the wall.";

		if (Input.GetKeyDown(KeyCode.R))		{myState = States.cell;} 
		else if (Input.GetKeyDown(KeyCode.T)) 	{myState = States.cell_mirror;}
	}

	void state_cell_mirror ()
	{
		gameText.text = "You are in a prison cell, now with a mirror in your hands. There are dirty sheets on a bed and the lock is still closed.\n\n" +
						"Press S to view Sheets, L to view Lock.";

		if (Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_1;} 
		else if (Input.GetKeyDown(KeyCode.L))	{myState = States.lock_1;}
	}

	void state_sheets_1 ()
	{
		gameText.text = "Bunch of dirty stuff, nothing interesting to look at even with a mirror.\n\n" +
						"Press R to return to cell.";

		if (Input.GetKeyDown(KeyCode.R))		{myState = States.cell_mirror;}
	}

	void state_lock_1 ()
	{
		gameText.text = "The doors are closed from the other side, you can use the mirror to see the keyhole.\n\n" +
						"Press R to return to cell or O to try to open the lock.";

		if (Input.GetKeyDown(KeyCode.R))		{myState = States.cell_mirror;} 
		else if (Input.GetKeyDown(KeyCode.O))	{myState = States.freedom;}
	}

	void state_freedom ()
	{
		gameText.text = "You are FREE!\n\n" + 
						"Press P to Play again or G to go to next level.";

		if (Input.GetKeyDown(KeyCode.P))		{myState = States.cell;}
		if (Input.GetKeyDown(KeyCode.G))
		{
			SceneManager.LoadScene("Corridor Scene");
		}
	}
}
