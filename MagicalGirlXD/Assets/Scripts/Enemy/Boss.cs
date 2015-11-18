using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	public int currentHealth;
	public int startingHealth;
	public int damage;
	public Transform shotPrefab;
	public BossAttack attackscript;
	bool baseReached = false;
	int phase = 0;
	bool cutsceneEnd = false;
	bool click = false;
	public int counter;
	public BossLoad bossssss;


	public GameObject bossMan;
	public GameObject player;
	public Player playerScript;

	public GameObject gymText;
	public GameObject studentText;

	//Home - 23, 33
	//Second - 23, 16
	//First - 15,25
	//Third - 30, 25
	private Vector2 firstBase = new Vector2(15,25);
	private Vector2 secondBase = new Vector2(23,16);
	private Vector2 thirdBase = new Vector2(30,25);
	private Vector2 homeBase = new Vector2(23,33);
	Vector3 movement;

	Rigidbody2D bossRigidBody;
	// Use this for initialization
	void Start () {
		//attackscript = GetComponentInChildren<BossAttack> ();
		player = GameObject.FindWithTag("Player");
		playerScript = player.GetComponent<Player>();
		bossRigidBody = GetComponent<Rigidbody2D> ();
		counter = 0;
		phase = 1;
	}

	void Move(float h, float v) {
		movement.Set(h, v, 0f);
		movement = movement.normalized * 6.0f * Time.deltaTime;
		bossRigidBody.MovePosition(this.gameObject.transform.position + movement);
	}
	// Update is called once per frame
	void Update () {

		if (!cutsceneEnd) {
			Cutscene();
		}
		else if (cutsceneEnd && phase == 1) {
			MovePhase (phase);
		} 

		else if (phase == 2) {
			MovePhase (phase);
		} 

		else if (phase == 3) {
			MovePhase (phase);
		} 

		else if (phase == 4) {
			MovePhase (phase);
		} 
	}


	void MovePhase(int baseNum) {
		if (baseNum == 2) {
			if(transform.position.x < 23 && transform.position.y > 16 && baseReached != true)
				Move(secondBase.x - transform.position.x, secondBase.y - transform.position.y);
			else {
				baseReached = true;
				AttackPhase(baseNum);
				phase++;
			}
		}
		
		if (baseNum == 3) {
			if(transform.position.x < 30 && transform.position.y < 25 && baseReached != true )
				Move(thirdBase.x - transform.position.x, thirdBase.y - transform.position.y);
			else {
				baseReached = true;
				AttackPhase(baseNum);
				phase++;
			}
		}
		
		if (baseNum == 4) {
			if(transform.position.x > 23 && transform.position.y < 33 && baseReached != true)
				Move(homeBase.x - transform.position.x, homeBase.y - transform.position.y);
			else {
				baseReached = true;
				AttackPhase(baseNum);
				phase++;
			}
		}
		
		if (baseNum == 1) { 
			if(transform.position.x > 15 && transform.position.y > 25 && baseReached != true)
				Move(firstBase.x - transform.position.x, firstBase.y - transform.position.y);
			else {
				baseReached = true;
				AttackPhase(baseNum);
				phase++;
			}
		}
	}

	void AttackPhase(int baseNum){
		if (baseNum == 1) {
			attackscript.Attack(player);
		}

		if (baseNum == 2) {
			attackscript.Attack(player);
		}

		if (baseNum == 3) {
			attackscript.Attack(player);
		}

		if (baseNum == 4) { 
			attackscript.Attack(player);
		}

		baseReached = false;
	}

	public void OnChildTriggerEnter(string aName, Collider2D aOther) {

	}

	public void Cutscene() {
		if (counter == 0) {
			gymText.SetActive (true);
		}
		playerScript.enabled = false;
		if (Input.GetKeyDown ("enter") || Input.GetMouseButtonDown (0)) {
			if(counter == 0) {
				counter++;
				gymText.SetActive(false);
				studentText.SetActive(true);
			}
			else if(counter == 1)
			{
				counter++;
				studentText.SetActive(false);
				playerScript.enabled = true;
				bossssss.maincam.transform.position = player.transform.position;
				cutsceneEnd = true;
			}
		}
	}


}
