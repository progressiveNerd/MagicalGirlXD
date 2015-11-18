using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	public int currentHealth;
	public int startingHealth;
	public int damage;
	public Transform shotPrefab;
	public BossAttack attackscript;
	bool baseReached = false;
	int phase = 4;

	public GameObject bossMan;
	public GameObject player;
	public Player playerScript;

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

	}

	void Move(float h, float v) {
		movement.Set(h, v, 0f);
		movement = movement.normalized * 1.0f * Time.deltaTime;
		bossRigidBody.MovePosition(this.gameObject.transform.position + movement);
	}
	// Update is called once per frame
	void Update () {
		if (!baseReached) {
			MovePhase (phase);
		} 


	}


	void MovePhase(int baseNum) {
		if (baseNum == 2) {
			if(transform.position.x < 23 && transform.position.y > 16)
				Move(secondBase.x - transform.position.x, secondBase.y - transform.position.y);
			else {
				baseReached = true;
			}
		}
		
		if (baseNum == 3) {
			if(transform.position.x < 30 && transform.position.y < 25 )
				Move(thirdBase.x - transform.position.x, thirdBase.y - transform.position.y);
			else
				baseReached = true;
		}
		
		if (baseNum == 4) {
			if(transform.position.x > 23 && transform.position.y < 33)
				Move(homeBase.x - transform.position.x, homeBase.y - transform.position.y);
			else
				baseReached = true;
		}
		
		if (baseNum == 1) { 
			if(transform.position.x > 15 && transform.position.y > 25)
				Move(firstBase.x - transform.position.x, firstBase.y - transform.position.y);
			else {
				baseReached = true;
				AttackPhase(1);
			}
		}
	}

	void AttackPhase(int baseNum){
		if (baseNum == 1) {
			attackscript.Attack(player);
		}

		if (baseNum == 2) {

		}

		if (baseNum == 3) {

		}

		if (baseNum == 4) { 

		}

	}

	public void OnChildTriggerEnter(string aName, Collider2D aOther) {

	}



}
