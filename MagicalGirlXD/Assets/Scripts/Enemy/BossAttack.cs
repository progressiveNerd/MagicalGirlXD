using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour {
	public float range = 150f;
	public Transform shotPrefab;
	public Boss manager;


	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		manager.OnChildTriggerEnter(name, other);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Attack(GameObject player) {
		var shotTransform = Instantiate(shotPrefab) as Transform;
		shotTransform.position = transform.position;
		ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
		if (shot != null) {
			shot.isEnemyShot = true;
			shot.direction = player.transform.position - transform.position;
			shot.direction.z = 0f;
			shot.direction.Normalize();
		}
	}
}
