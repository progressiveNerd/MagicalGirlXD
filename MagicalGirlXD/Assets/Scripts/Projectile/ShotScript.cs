using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {
	public bool isEnemyShot = false;
	public float speed = 10f;
	public float range = 10f;
	public int damage = 1;

	float elapsedDistance;
	Vector3 direction;
	Vector3 movement;
	Rigidbody2D body;

	void Start() {
		Destroy(gameObject, 5);
		body = GetComponent<Rigidbody2D>();

		Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		direction = mousePosVector - transform.position;
		direction.z = 0f;
		direction.Normalize();
		elapsedDistance = 0;
	}

	void FixedUpdate() {
		movement = new Vector3(
			speed * direction.x * Time.deltaTime,
			speed * direction.y * Time.deltaTime, 0f);
		body.MovePosition(transform.position + movement);
		elapsedDistance += movement.magnitude;
		if(elapsedDistance >= range)
			Destroy(gameObject, 0.5f);
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider is BoxCollider2D) {
			if (!isEnemyShot && otherCollider.gameObject.tag == "Enemy") {
				EnemyHealth eh = otherCollider.gameObject.GetComponent<EnemyHealth> ();
				eh.TakeDamage(damage);
				Destroy(gameObject, 0f);
			}
		}
	}
}
