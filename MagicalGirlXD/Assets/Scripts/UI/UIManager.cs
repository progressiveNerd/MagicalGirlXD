using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public Player player;
	public Image keyImage;
	public Image schoolKeyImage;
	private Color temp;

	void Update() {
		if (player.hasWaterKey) {
			temp = keyImage.color;
			temp.a = 1.0f;
			keyImage.color = temp;
		}
		if (player.hasSchoolkey) {
			temp = schoolKeyImage.color;
			temp.a = 1.0f;
			schoolKeyImage.color = temp;
		}
		if (!player.hasWaterKey) {
			temp = keyImage.color;
			temp.a = 0.0f;
			keyImage.color = temp;

			}
		if (!player.hasSchoolkey) {
			temp = schoolKeyImage.color;
			temp.a = 0.0f;
			schoolKeyImage.color = temp;
		}
	}

}
