using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectSwitch : MonoBehaviour {

	public Player player;
	public GameObject canvas;
	// Use this for initialization
	void Start () {

	}

	public void clickNO() {
		canvas.SetActive (false);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player") {
			Application.LoadLevel(3);
		}
	}
}
