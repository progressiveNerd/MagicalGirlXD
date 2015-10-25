using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {
	
	public void changeScene (string sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
	}
}
