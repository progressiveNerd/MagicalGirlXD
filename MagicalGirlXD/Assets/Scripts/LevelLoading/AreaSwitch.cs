using UnityEngine;
using System.Collections;

public class AreaSwitch : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Debug.Log("Trigger is on");
		if(other.gameObject.tag =="Player"){
			Debug.Log("I am here ");
			Application.LoadLevel(1);
		}      
	}
}
