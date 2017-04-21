using UnityEngine;

public class Tower : MonoBehaviour {

	private Transform target;
	private AudioSource shotSound;

	[Header("Attributes")]
	
	public float towerRange = 15f;
	public float turnSpeed = 10f;
	public float fireRate = 1f;
	private float nextFire = 1f;

	[Header("Required Fields")]

	public Transform rotatingPart;
	public string enemyTag = "Enemy";

	[Header("Fire Fields")]

	public GameObject bulletPrefab;
	public Transform fireStartPoint;


	void Start () 
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f); // wywoływanie funkcji 2x na sekundę (zamiast multum razy w Update)
		shotSound = GetComponent<AudioSource>();
	}

	// wyszukiwanie wroga w zasięgu
	void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity; // przed znalezieniem obiektu dystans jest nieskończony, nie wejdzie nam w obszar zasięgu wieży
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);

			if (distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;	
			}
		}

		// znaleziony wróg będący w zasięgu wieży staje się jej celem
		if (nearestEnemy != null && shortestDistance <= towerRange) {
			target = nearestEnemy.transform;	
		} else 
		{
			target = null;
		}
	}

	void Update ()
	{
		if (target == null) {
			return;	
		}

		Vector3 dir = target.position - transform.position; // dystans pomiędzy nami a wrogiem
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp (rotatingPart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; // Quaternion.Lerp służy do płynnego przejścia między stanami (nie będzie nienaturalnego przeskoku)

		if (gameObject.tag == "Canon") 
		{
			rotatingPart.rotation = Quaternion.Euler (0f, rotation.y, 0f);
		} 
		else if (gameObject.tag == "Mage") 
		{
			rotatingPart.rotation = Quaternion.Euler (-90, 0f, rotation.z);
		}

		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Shoot ();
		}
	}

	void Shoot ()
	{
		GameObject bulletGameObj = (GameObject)Instantiate(bulletPrefab, fireStartPoint.position, fireStartPoint.rotation);
		Bullet bullet = bulletGameObj.GetComponent<Bullet>();
		shotSound.Play();

		if (bullet != null)
			bullet.Chase(target);
	}

	// funkcja uwidaczniająca zasięg naszej wieżyczki
	void OnDrawGizmosSelected () 
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, towerRange);
	}
}
