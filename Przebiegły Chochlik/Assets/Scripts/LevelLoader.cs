using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour 
{
	public void LoadLevel (string name) 
	{
		SceneManager.LoadScene(name);
	}

	public void GameExit ()
	{
		Application.Quit();
	}
}
