using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class AnnoyingImp : MonoBehaviour 
{
	public Text gameText;
	public GameObject startButton;
	
	private int max;
	private int min;
	private int guess;
	private bool canPlay;
	
	void Start () 
	{
		StartGame();
	}
	

	void Update ()
	{
		if (canPlay) {
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				min = guess;
				NextGuess();
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow)) 
			{
				max = guess;
				NextGuess();
			}
			else if (Input.GetKeyDown(KeyCode.Return)) 
			{
				SceneManager.LoadScene("Finish");	
			}
		}
	}

	public void StartGame ()
	{

		max = 1000;
		min = 1;
		guess = 500;
		
		gameText.text = "Niechaj rozpocznie się bitwa umysłów!\n\n" + 
						"Wybierz sobie jakiś numer, tylko przypadkiem nie popal żadnych zwojów podczas burzy mózgów!\n\n" +
						"Żądam, abyś nie mógł wybrać liczby większej niż " + max + "... Bo tak!\n\n" +
						"Żądam bardziej żądając, abyś nie zszedł poniżej cyfry " + min + "." + "\n\n";
		max += 1;
		canPlay = false;
		startButton.SetActive(true);
	}

	public void FirstGuess ()
	{
		gameText.text = "Wymyśliłeś już coś? Czekam!\n\n" +
						"Ta liczba jest większa czy mniejsza niż "+ guess + "?\n\n" +
						"Strzałka do góry = więcej, strzałka w dół = mniej lub enter = trafione";
		canPlay = true;
		startButton.SetActive(false);
	}

	public void NextGuess ()
	{
		guess = (max + min) / 2;

		gameText.text = "Czy ten żałosny numer, który wybrałeś, jest większy czy mniejszy niż " + guess + "?\n\n" +
						"Strzałka do góry = więcej, strzałka w dół = mniej lub enter = trafione";
	}
}
