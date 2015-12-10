using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Doors : MonoBehaviour {
	public Player playerScript;
	public GameObject info;
	LevelManager a;
	Text[] things;
	Text alert;
	Image image;
	// Use this for initialization
	void Start () {
		playerScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		a = GameObject.FindGameObjectWithTag ("Manage").GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log (col.name);
		if (col.name == "Player") {
			if (Application.loadedLevel == 1) {
				a.Info.SetActive(true);
				alert = a.Info.GetComponentInChildren<Text>();
				alert.text = "You don't have the key! Check the soccer field!";
			}
		}
	}
	void OnTriggerExit2D(Collider2D col) {
		if (col.name == "Player") {
			a.Info.SetActive(false);
		}
	}

}
