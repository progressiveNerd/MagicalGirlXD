using UnityEngine;
using System.Collections;

public class AreaSwitch : MonoBehaviour {
	Player player;
	public GameObject preserved;

	void Awake() {
		player = GameObject.FindWithTag ("Player").GetComponent<Player>();
		preserved = GameObject.FindWithTag("Preserve");
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			preserved.GetComponent<Preserve>().setPosition(player.transform.position);
			preserved.GetComponent<Preserve>().toggleLoad();
			if(player.hasWaterKey) {
				if (Application.loadedLevel == 1 && ((player.transform.position.x >= 15 && player.transform.position.x <= 23)
				                                     || (player.transform.position.x >=59 && player.transform.position.x <=68)))
					Application.LoadLevel(2);
				else if (Application.loadedLevel == 2 && ((player.transform.position.x >= 11 && player.transform.position.x <= 23)
				                                          || (player.transform.position.x >=79 && player.transform.position.x <=92)))
					Application.LoadLevel(1);
			}
			if(player.hasSchoolkey) {
				if (Application.loadedLevel == 1 && ((player.transform.position.x >= 40 && player.transform.position.x <= 42)))
				{
					Application.LoadLevel (4);
				}
				else if (Application.loadedLevel == 2 && ((player.transform.position.x >= 46 && player.transform.position.x <= 56)))
				{
					Application.LoadLevel (4);
				}
			}
		}
	}
}
