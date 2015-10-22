using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {
	public int damage = 1;
	public bool isEnemyShot = false;
	public float speed = 10f;

	Vector3 direction;
	Vector3 movement;
	Rigidbody2D body;

	void Start() {
		Destroy(gameObject, 20);
		body = GetComponent<Rigidbody2D>();

		Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		direction = mousePosVector - transform.position;
		direction.z = 0f;
		direction.Normalize();
	}

	void FixedUpdate() {
		movement = new Vector3(
			speed * direction.x * Time.deltaTime,
			speed * direction.y * Time.deltaTime, 0f);
		body.MovePosition(transform.position + movement);
	}
}
