using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;
	public int health = 100;
	public int moneyGain = 50;

	public GameObject destroyImpact;

	private Transform target;
	private int wavepointIndex = 0;

	void Start () 
	{
		target = Waypoints.points[0];
	}

	void Update () 
	{
		Vector3 destination = target.position - transform.position;

		transform.Translate(destination.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f) 
		{
			GetNextPoint();	
		}
	}

	public void TakeDamage (int amount)
	{
		health -= amount;

		if (health <= 0) 
		{
			Die();
		}
	}

	void Die ()
	{
		PlayerStats.Money += moneyGain;

		GameObject deathEffect = (GameObject)Instantiate(destroyImpact, transform.position, Quaternion.identity);
		Destroy(deathEffect, 5f);

		Destroy(gameObject);
	}

	// przejście do następnego punktu ruchu
	void GetNextPoint () 
	{
		if (wavepointIndex >= Waypoints.points.Length - 1) 
		{
			EndPath();
			return;
		}
		
		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	// po dotarciu do ostatniego punktu obiekt wroga jest niszczony, a liczba żyć zmniejszona o 1
	void EndPath() 
	{
		PlayerStats.Lives--;
		Destroy(gameObject);
	}
}
