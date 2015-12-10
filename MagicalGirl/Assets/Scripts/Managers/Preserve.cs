using UnityEngine;
using System.Collections;

public class Preserve : MonoBehaviour {
	public GameObject player;
	public Player playerscript;
	public GameObject pres;

	int currenthealth;
	public Vector3 pos;
	public bool hasWaterKey = false;
	public bool hasSchoolKey = false;
	public bool hasBossKey = false;
	public bool loaded;
	public bool deathload = false;

	// Use this for initialization
	void Start () {
		loaded = false;
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
	}
	public void setPosition(Vector3 a) {
		pos = a;
	}

	public void toggleLoad() {
		if (!loaded)
			loaded = true;
		if (playerscript.hasDied) {
			deathload = true;
		}
	}


	public void deathLoad() {
		deathload = false;
	}
}
