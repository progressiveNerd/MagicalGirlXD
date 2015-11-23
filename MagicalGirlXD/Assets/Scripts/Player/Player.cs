using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity {
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public int startingHealth = 5;
	public int currentHealth;
	public bool hasWaterKey = false;

	public Slider healthSlider;
    public AudioClip pickupSound;
	public AudioClip damageSound;
	public AudioClip deathSound;
	
    Animator anim;
    AudioSource audioSource;
	FacingDirection direction = FacingDirection.Front;
    PlayerAttack playerAttack;
    Rigidbody2D rigidBody;
    Vector3 movement;

	void Awake() {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerAttack = GetComponent<PlayerAttack>();
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Animating(h, v);
	}

    void Move(float h, float v) {
        movement.Set(h, v, 0f);
        if (Input.GetKey(KeyCode.LeftShift))
            movement = movement.normalized * runSpeed * Time.deltaTime;
        else
            movement = movement.normalized * walkSpeed * Time.deltaTime;
        rigidBody.MovePosition(transform.position + movement);
    }

    void Turning() {
        Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerToMouse = mousePosVector - transform.position;
        playerToMouse.z = 0f;
        if (Mathf.Abs(playerToMouse.y) >= Mathf.Abs(playerToMouse.x)) {
            if (playerToMouse.y <= 0)
                direction = FacingDirection.Front;
            else direction = FacingDirection.Back;
        } else {
            if (playerToMouse.x <= 0)
                direction = FacingDirection.Left;
            else direction = FacingDirection.Right;
        }
    }

    void Animating(float h, float v) {
        bool walking = h != 0f || v != 0f;
        //anim.SetBool("IsWalking", walking);
        anim.SetInteger("Direction", (int)direction);
    }

    public override void TakeDamage(int amount) {
        currentHealth -= amount;
		healthSlider.value = currentHealth;

        //playerAudio.Play();
        if (currentHealth <= 0)
        {
            Death();
            
        }
    }

    protected override void Death() {
        //playerShooting.DisableEffects();
        //anim.SetTrigger("Die");
        //playerAudio.clip = deathClip;
        //playerAudio.Play();
        playerAttack.enabled = false;
		this.enabled = false;
        //Destroy(gameObject, 1f);
    }

    public void RestartLevel() {
        Application.LoadLevel(Application.loadedLevel);
    }


	void OnTriggerEnter2D(Collider2D col) {
		/*
		if (col.gameObject.name == "AreaSwitch(Clone)") {
			if(hasWaterKey) {
                if (Application.loadedLevel == 1)
                    Application.LoadLevel(2);
                else if (Application.loadedLevel == 2)
                    Application.LoadLevel(1);
			}
		}
		if (col.gameObject.name == "WaterKey") {
			hasWaterKey = true;
			Destroy(col.gameObject);
            audioSource.clip = pickupSound;
            audioSource.Play();
		}
		*/
	}
}
