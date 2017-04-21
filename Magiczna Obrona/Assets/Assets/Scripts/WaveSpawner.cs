using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public Transform enemy;
	public Transform spawnPoint;
	public Text waveCountdownText;

	public float timeBetweenWaves;

	private float countdown = 2f;
	private int waveIndex = 0;

	void Start () 
	{
		CountdownUpdate();
	}

	void Update () 
	{
		if (countdown <= 0f) 
		{
			StartCoroutine (SpawnWave());
			countdown = timeBetweenWaves;
		}

		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); // nie chcemy aby licznik spadł poniżej zera

		CountdownUpdate();
	}

	IEnumerator SpawnWave ()
	{
		waveIndex++;

		for (int i = 0; i < waveIndex; i++) 
		{
			SpawnEnemy();
			yield return new WaitForSeconds (0.5f);
		}
	}

	public void SpawnEnemy () 
	{
		Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
	}

	public void CountdownUpdate () 
	{
		waveCountdownText.text = string.Format("{0:00.00}", countdown); // zmieniamy format wyświetlania czasu
	}
}
