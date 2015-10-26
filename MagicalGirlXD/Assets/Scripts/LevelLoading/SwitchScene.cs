using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {
	
	public void changeScene (int sceneToChangeTo, Player player) {
		DontDestroyOnLoad (player);
		Application.LoadLevel(sceneToChangeTo);

	}
}
