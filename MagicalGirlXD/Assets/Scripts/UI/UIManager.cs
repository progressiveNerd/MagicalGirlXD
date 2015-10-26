using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public Player player;
	public Image keyImage;
	private Color temp;

	void Update() {
		if (player.waterKey) {
			temp = keyImage.color;
			temp.a = 1.0f;
			keyImage.color = temp;
		}
		else {
			temp = keyImage.color;
			temp.a = 0.0f;
			keyImage.color = temp;
		}
	}

}
