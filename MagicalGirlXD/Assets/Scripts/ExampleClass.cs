﻿using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
	void OnCollisionStay2D(Collision2D collisionInfo) {
		Debug.Log(collisionInfo.collider.gameObject.name);
	}
}