using UnityEngine;
using System.Collections;

public class Boss : Entity {
	public int currentHealth;
	public int startingHealth;
	public int damage;
	public Transform shotPrefab;
	public BossAttack attackscript;
	bool baseReached = false;
	bool attacked = false;
	bool waited = false;
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
	void Start() {
		//attackscript = GetComponentInChildren<BossAttack> ();
		player = GameObject.FindWithTag("Player");
		playerScript = player.GetComponent<Player>();
		bossRigidBody = GetComponent<Rigidbody2D> ();
		counter = 0;
		phase = 1;
		currentHealth = startingHealth;
	}

	void Update () {
		if (!cutsceneEnd)
			Cutscene ();
		else if (cutsceneEnd && phase == 1)
			MovePhase ();
		else if (phase == 2)
			MovePhase ();
		else if (phase == 3)
			MovePhase ();
		else if (phase == 4)
			MovePhase ();
	}

	void Move(float h, float v, float speed) {
		movement.Set(h, v, 0f);
		movement = movement.normalized * speed * Time.deltaTime;
		bossRigidBody.MovePosition(this.gameObject.transform.position + movement);
	}

	void MovePhase() {
		Debug.Log (phase);
		if (phase == 2) {
			if(transform.position.x < 23 && transform.position.y > 16 && baseReached != true)
				Move(secondBase.x - transform.position.x, secondBase.y - transform.position.y, 10.0f);
			else {
				baseReached = true;
				if(!waited)
					waitPhase();
			}
		}
		
		else if (phase == 3) {
			if(transform.position.x < 30 && transform.position.y < 25 && baseReached != true )
				Move(thirdBase.x - transform.position.x, thirdBase.y - transform.position.y, 10.0f);
			else {
				baseReached = true;
				if(!waited)
					waitPhase();
			}
		}
		
		else if (phase == 4) {
			if(transform.position.x > 23 && transform.position.y < 33 && baseReached != true)
				Move(homeBase.x - transform.position.x, homeBase.y - transform.position.y, 10.0f);
			else {
				baseReached = true;
				if(!waited)
					waitPhase();
			}
		}
		
		else if (phase == 1) { 
			if(transform.position.x > 15 && transform.position.y > 25 && baseReached != true)
				Move(firstBase.x - transform.position.x, firstBase.y - transform.position.y, 10.0f);
			else {
				baseReached = true;
				if(!waited)
					waitPhase();

			}
		}
	}

	void AttackPhase(){
		if (phase == 1 && !attacked) {
			attackscript.Attack (player);
			phase++;
		} else if (phase == 2 && !attacked) {
			attackscript.Attack (player);
			phase++;
		} else if (phase == 3 && !attacked) {
			attackscript.Attack (player);
			phase++;
		} else if (phase == 4 && !attacked) {
			attackscript.Attack (player);
			phase = 1;
		}
		baseReached = false;
		attacked = true;
		waited = false;
	}

	public void Cutscene() {
		if (counter == 0) {
			gymText.SetActive (true);
		}
		playerScript.enabled = false;
		player.GetComponent<PlayerAttack> ().enabled = false;
		if (Input.GetKeyDown ("enter") || Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.E)) {
			if(counter == 0) {
				counter++;
				gymText.SetActive(false);
				studentText.SetActive(true);
			}
			else if(counter == 1) {
				counter++;
				studentText.SetActive(false);
				playerScript.enabled = true;
				player.GetComponent<PlayerAttack> ().enabled = true;
				bossssss.maincam.transform.position = player.transform.position;
				cutsceneEnd = true;
			}
		}
	}

	protected override void Death() {
		this.GetComponent<Boss> ().enabled = false;
	}

	public override void TakeDamage(int amount) {
		if(!baseReached)
			currentHealth --;
		if (currentHealth <= 0) {
			Death();
		}
	}

	public void waitPhase() {
		waited = true;
		Invoke("AttackPhase",3.0f);
		attacked = false;

	}

}
