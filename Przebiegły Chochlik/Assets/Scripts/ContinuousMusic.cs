using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ContinuousMusic : MonoBehaviour 
{

	private static ContinuousMusic instance = null;

	public static ContinuousMusic Instance 
	{
		get { return instance; }
 	}

 	void Awake() 
 	{
    	if (instance != null && instance != this) 
    	{
        	Destroy(this.gameObject);
         	return;
     	} else {
         	instance = this;
     	}

     	DontDestroyOnLoad(this.gameObject);
 	}
}
