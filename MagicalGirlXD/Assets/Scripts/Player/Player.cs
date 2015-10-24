using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public int currentHealth;
    public int startingHealth = 5;
    public FacingDirection direction = FacingDirection.Front;

    bool detected;
    
    Animator anim;
    PlayerShooting playerShooting;
    Rigidbody2D rigidBody;
    Vector3 movement;

	void Awake() {
        currentHealth = startingHealth;
        detected = false;

        anim = GetComponent<Animator>();
        playerShooting = GetComponent<PlayerShooting>();
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

    public void TakeDamage(int amount)
    {
        //damaged = true;
        currentHealth -= amount;
        //playerAudio.Play();
        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {
        //playerShooting.DisableEffects();
        //anim.SetTrigger("Die");
        //playerAudio.clip = deathClip;
        //playerAudio.Play();
        playerShooting.enabled = false;
        //Destroy(gameObject, 1f);
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
