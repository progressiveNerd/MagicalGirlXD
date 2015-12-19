using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Boss2 : Entity
{
	public int currentHealth;
	public int startingHealth;
	public int damage;
	int counterrrrrrr = 0;
	public Transform shotPrefab;
	public BossAttack2 attackscript;
	bool baseReached = false;
	bool attacked = false;
	bool waited = false;
	int phase = 0;
	int frameNumber = 0;
	bool cutsceneEnd = false;
	bool click = false;
	public int counter;
	public TextureLoad2 bossssss;
	public Camera mainCam;
	public CameraFollow yep;
	Animator anim;
	
	public GameObject bossMan;
	public GameObject player;
	public Player playerScript;
	
	public GameObject gymText;
	public GameObject studentText;
	public Text textbox;
	public GameObject canv;
	public Slider health;
	public GameObject levelComplete;
	
	float speed;
	//Home - 23, 33
	//Second - 23, 16
	//First - 15,25
	//Third - 30, 25
	private Vector2 firstBase = new Vector2(11, 28);
	private Vector2 secondBase = new Vector2(11, 12);
	private Vector2 thirdBase = new Vector2(27, 12);
	private Vector2 homeBase = new Vector2(27, 28);
	Vector3 movement;
	
	Rigidbody2D bossRigidBody;
	
	void Start()
	{
		player = GameObject.FindWithTag("Player");
		playerScript = player.GetComponent<Player>();
		bossRigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		counter = 0;
		phase = 1;
		speed = 5.0f;
		currentHealth = startingHealth;
		Cutscene();
	}
	
	void Update()
	{
		if (!cutsceneEnd)
			Cutscene();
		if(!waited && cutsceneEnd) {
			if (phase == 1)
				MovePhase();
			else if (phase == 2)
				MovePhase();
			else if (phase == 3)
				MovePhase();
			else if (phase == 4)
				MovePhase();
		}
		if (waited) {
			AttackPhase();
		}
	}
	
	void Move(float h, float v, float speed)
	{
		movement.Set(h, v, 0f);
		movement = movement.normalized * speed * Time.deltaTime;
		bossRigidBody.MovePosition(this.gameObject.transform.position + movement);
	}
	
	void MovePhase()
	{
		attacked = false;
		if (phase == 2)
		{
			if (transform.position.x <= 11 && transform.position.y >= 12 && baseReached != true)
				Move(secondBase.x - transform.position.x, secondBase.y - transform.position.y, speed);
			else
			{
				
				if (!waited)
					waitPhase();
			}
		}
		
		else if (phase == 3)
		{
			if (transform.position.x <= 27 && transform.position.y <= 12 && baseReached != true)
				Move(thirdBase.x - transform.position.x, thirdBase.y - transform.position.y, speed);
			else
			{
				if (!waited)
					waitPhase();
			}
		}
		
		else if (phase == 4)
		{
			if (transform.position.x >= 27 && transform.position.y <= 28 && baseReached != true)
				Move(homeBase.x - transform.position.x, homeBase.y - transform.position.y, speed);
			else
			{
				if (!waited)
					waitPhase();
			}
		}
		
		else if (phase == 1)
		{
			if (transform.position.x >= 11 && baseReached != true)
				Move(firstBase.x - transform.position.x, firstBase.y - transform.position.y, speed);
			else
			{
				if (!waited)
					waitPhase();
			}
		}
	}
	
	void AttackPhase()
	{
		baseReached = true;
		if (phase == 1 && !attacked)
		{
//			anim.SetTrigger("Attack");
			attackscript.SpecialAttack1(player);
			
		}
		else if (phase == 2 && !attacked)
		{
	//		anim.SetTrigger("Attack");
			attackscript.SpecialAttack2(player);
		}
		else if (phase == 3 && !attacked)
		{
//			anim.SetTrigger("Attack");
			attackscript.SpecialAttack3(player);
		}
		else if (phase == 4 && !attacked)
		{
//			anim.SetTrigger("Attack");
			attackscript.Attack(player);
		}
		
		if(counterrrrrrr == 0)
			Invoke("AttackWait",2.0f);
		counterrrrrrr++;
	}
	
	public void Cutscene()
	{

				cutsceneEnd = true;
			

	}
	
	protected override void Death()
	{
		this.GetComponent<Boss2>().enabled = false;
		levelComplete.SetActive(true);
		playerScript.enabled = false;
		player.GetComponent<PlayerAttack>().enabled = false;
	}
	
	public override void TakeDamage(int amount)
	{
		if (!baseReached)
			currentHealth--;
		health.value = currentHealth;
		if (currentHealth <= 0)
			Death();
	}
	
	public void waitPhase()
	{
		baseReached = true;
		Invoke("superWait", 1.0f);
	}
	public void superWait()
	{
		waited = true;
	}
	public void AttackWait()
	{
		attacked = true;
		waited = false;
		baseReached = false;
		if (phase != 4)
			phase++;
		else 
			phase = 1;
		counterrrrrrr = 0;
	}
}
