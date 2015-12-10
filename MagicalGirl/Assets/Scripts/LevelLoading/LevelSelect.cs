using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

	Player player;
	GameObject confirm;
	public int scene;
	
	void Awake() {
		player = GameObject.FindWithTag ("Player").GetComponent<Player>();
	}
	
	void OnTriggerEnter2D(Collider2D col){
		/*
		Debug.Log("Trigger is on");
		if(other.gameObject.tag =="Player"){
			Debug.Log("I am here ");
			Application.LoadLevel(1);
		}
		*/
		if (col.Equals(player.GetComponent<BoxCollider2D>())) {
			Debug.Log("Hiiiii");
			Application.LoadLevel(scene);
		}
	}
}
