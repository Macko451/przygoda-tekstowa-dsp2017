using UnityEngine;

public class Bullet : MonoBehaviour 
{

	public float speed = 70f;
	public GameObject impactEffect;

	private Transform target;

	// podążanie kuli za wrogiem
	public void Chase (Transform chasedTarget)
	{
		target = chasedTarget;
	}
	
	void Update () 
	{
		// zabezpieczenie przed zniknięciem celu
		if (target == null) 
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame) // magnitude nawiązuje do długości odcinka dir, jeżeli jest mniejszy niż distanceThisFrame, oznacza to, że dosięgliśmy celu
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World); // normalizujemy wartość - niezależnie od odległości od celu szybkość ruchu jest jednakowa
	}

	public void HitTarget() 
	{
		GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectInstance, 2f);

		Damage(target);
		Destroy(gameObject);
	}

	void Damage (Transform enemy)
	{
		Destroy(enemy.gameObject);
	}
}
