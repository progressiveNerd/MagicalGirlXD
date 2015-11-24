using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	public Player player;
	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		/*
		if (col.gameObject.name == "AreaSwitch(Clone)") {
			if(hasWaterKey) {
				if (Application.loadedLevel == 1)
					Application.LoadLevel(2);
				else if (Application.loadedLevel == 2)
					Application.LoadLevel(1);
			}
		}
		*/
		if (col.gameObject.tag == "Player") {
			if(this.name == "SchoolKey")
			{
				player.hasSchoolkey = true;
			}
			if(this.name == "WaterKey") {
				player.hasWaterKey = true;
			}
			//audioSource.clip = pickupSound;
			//audioSource.Play();
			Destroy(gameObject);
		}
	}
}
