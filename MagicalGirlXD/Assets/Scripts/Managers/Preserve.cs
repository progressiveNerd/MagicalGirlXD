using UnityEngine;
using System.Collections;

public class Preserve : MonoBehaviour {
	public GameObject player;
	public Player playerscript;
	public GameObject pres;

	int currenthealth;
	public Vector3 pos;
	public bool hasWaterKey;
	public bool hasSchoolKey;

	// Use this for initialization
	void Start () {

	}

	void Awake () {
		DontDestroyOnLoad (pres);
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}
		if (playerscript == null) {
			playerscript = player.GetComponent<Player>();
		}
		if (playerscript.hasWaterKey) {
			pos = player.transform.position;
			hasWaterKey = playerscript.hasWaterKey;
		}
	}
}
