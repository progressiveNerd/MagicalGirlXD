using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public float projectileSpeed = 10f;
	Vector3 movement;
	Rigidbody2D playerRigidBody;
	
	void Start() {
		Destroy(gameObject, 5);
	}

	void Update() {

	}
}
