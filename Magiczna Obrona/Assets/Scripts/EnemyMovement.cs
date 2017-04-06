using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed;

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

	void GetNextPoint () 
	{
		if (wavepointIndex >= Waypoints.points.Length - 1) 
		{
			Destroy(gameObject);
			return;
		}
		
		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}
}
