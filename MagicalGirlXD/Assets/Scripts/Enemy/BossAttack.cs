using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour {
	public float range = 150f;
	public Transform shotPrefab;
	public Boss manager;


	// Use this for initialization
	void Start () {
	
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

	public void SpecialAttack1(GameObject player) {
		var shotTransform = Instantiate(shotPrefab) as Transform;
		var shotTransform1 = Instantiate(shotPrefab) as Transform;
		var shotTransform2 = Instantiate(shotPrefab) as Transform;
		var shotTransform3 = Instantiate(shotPrefab) as Transform;

		shotTransform.position = transform.position;
		shotTransform1.position = transform.position;
		shotTransform2.position = transform.position;
		shotTransform3.position = transform.position;
		ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
		ShotScript shot1 = shotTransform1.gameObject.GetComponent<ShotScript>();
		ShotScript shot2 = shotTransform2.gameObject.GetComponent<ShotScript>();
		ShotScript shot3 = shotTransform3.gameObject.GetComponent<ShotScript>();
		if (shot != null) {
			shot.isEnemyShot = true;
			shot.direction = player.transform.position - transform.position;
			shot.direction.z = 0f;
			shot.direction.Normalize();

			shot1.isEnemyShot = true;
			shot1.direction = player.transform.position - transform.position;
			shot1.direction.z = 0f;
			shot1.direction.Normalize();

			shot1.isEnemyShot = true;
			shot1.direction = player.transform.position - transform.position;
			shot1.direction.z = 0f;
			shot1.direction.Normalize();

			shot1.isEnemyShot = true;
			shot1.direction = player.transform.position - transform.position;
			shot1.direction.z = 0f;
			shot1.direction.Normalize();
		}
	}

	public void SpecialAttack2(GameObject player) {
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

	public void SpecialAttack3(GameObject player) {
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
