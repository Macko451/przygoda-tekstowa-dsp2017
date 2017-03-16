using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CorridorSceneController : MonoBehaviour {

	public Text gameText;

	private enum States {corridor_0, stairs_0, floor, closet_door, corridor_1, stairs_1, in_closet, corridor_2, stairs_2, corridor_3, courtyard};
	private States myState;

	void Start () 
	{
		myState = States.corridor_0;
	}

	void Update () 
	{
		
		switch (myState) 
		{
		case States.corridor_0:
			corridor_0 ();
			break;
		case States.stairs_0:
			stairs_0 ();
			break;
		case States.floor:
			floor ();
			break;
		case States.closet_door:
			closet_door ();
			break;
		case States.corridor_1:
			corridor_1();
			break;
		case States.stairs_1:
			stairs_1 ();
			break;
		case States.in_closet:
			in_closet ();
			break;
		case States.corridor_2:
			corridor_2 ();
			break;
		case States.stairs_2:
			stairs_2 ();
			break;
		case States.corridor_3:
			corridor_3 ();
			break;
		case States.courtyard:
			courtyard ();
			break;
		default:
			gameText.text = "Something wrong.";
			break;
		}

	}

	#region State handler methods
	void corridor_0 ()
	{
		gameText.text = "You are out of cell, but not out of trouble." +
						"You are in the corridor, there's a closet and some stairs leading to " +
						"the courtyard. There's also various detritus on the floor.\n\n" +
						"Press C to view the Closet, F to inspect the Floor, and S to climb the stairs.";

		if 	 	(Input.GetKeyDown(KeyCode.S))	{myState = States.stairs_0;} 
		else if (Input.GetKeyDown(KeyCode.F))	{myState = States.floor;} 
		else if (Input.GetKeyDown(KeyCode.C))	{myState = States.closet_door;}
	}

	void corridor_1 ()
	{
		gameText.text = "Still in the corridor. Floor is dirty. Hairclip in hand. " +
						"Now what? You wonder if that lock on the closet would succumb to " +
						"some lock-picking?\n\n" +
						"Press P to Pick the lock, and S to climb the Stairs.";

		if 		(Input.GetKeyDown(KeyCode.S))	{myState = States.stairs_1;} 
		else if (Input.GetKeyDown(KeyCode.P))	{myState = States.in_closet;}
	}

	void corridor_2 ()
	{
		gameText.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
						"Press C to revisit the Closet, and S to climb the stairs.";

		if 		(Input.GetKeyDown(KeyCode.C))	{myState = States.in_closet;} 
		else if (Input.GetKeyDown(KeyCode.S))	{myState = States.stairs_2;}
	}

	void corridor_3 ()
	{
		gameText.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
						"You strongly consider the run for freedom.\n\n" +
						"Press S to take the Stairs, or U to Undress";

		if 		(Input.GetKeyDown(KeyCode.U))	{myState = States.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S))	{myState = States.courtyard;}
	}

	void stairs_0 ()
	{
		gameText.text = "You start walking up the stairs towards the outside light. " +
						"You realise it's not a break time, and you'll be caught immediately. " +
						"You slither back down the stairs and reconsider it.\n\n" +
						"Press the R to Return to the corridor";

		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_0;}
	}

	void stairs_1 ()
	{
		gameText.text = "Unfortunately wielding a puny hairclip hasn't given you the " +
						"confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
						"Press R to Retreat down the stairs";

		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_1;}
	}

	void stairs_2 ()
	{
		gameText.text = "You feel smug for picking the closed door open, and are still armed with " +
						"a hairclip (now badly bent). Even these achievements together don't give " +
						"you courage to climb up the stairs to your death!\n\n" +
						"Press R to Return to the corridor";

		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_2;}
	}

	void closet_door ()
	{
		gameText.text = "You are looking at a closet door, unfortunately it's locked. " +
						"Maybe you could find something around to help enourage it open?\n\n" +
						"Press R to Return to the corridor";

		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_0;}
	}

	void in_closet ()
	{
		gameText.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
						"Seems like your day is looking-up.\n\n" +
						"Press D to Dress up, or R to Return to the corridor";

		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_2;}
		else if (Input.GetKeyDown(KeyCode.D))	{myState = States.corridor_3;}
	}

	void floor ()
	{
		gameText.text = "Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
						"Press R to Return to the standing, or H to take the Hairclip.";

		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_0;} 
		else if (Input.GetKeyDown(KeyCode.H)) 	{myState = States.corridor_1;}
	}

	void courtyard ()
	{
		gameText.text = "You walk through the courtyard dressed as a cleaner. " +
						"The guard tips his hat at you as you waltz, claiming " +
						"your freedom. Your heart races as you walk into the sunset.\n\n" +
						"Press P to Play again.";

		if 		(Input.GetKeyDown(KeyCode.P))	{myState = States.corridor_0;}
		if 		(Input.GetKeyDown(KeyCode.G)) 
		{
			SceneManager.LoadScene("Magic Main");
		}
	}
	#endregion
}