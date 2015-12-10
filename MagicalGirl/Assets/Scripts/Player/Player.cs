using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public int startingHealth = 5;
    public int currentHealth;
    public bool hasWaterKey = false;
    public bool hasSchoolKey = false;
    public bool hasBossKey = false;
    public bool hasDied = false;
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
    bool wasMoving;
    FacingDirection prevDirection;

    void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerAttack = GetComponent<PlayerAttack>();
        rigidBody = GetComponent<Rigidbody2D>();

        if (GameObject.FindGameObjectWithTag("Preserve") != null)
        {
            hasWaterKey = GameObject.FindGameObjectWithTag("Preserve").GetComponent<Preserve>().hasWaterKey;
            hasSchoolKey = GameObject.FindGameObjectWithTag("Preserve").GetComponent<Preserve>().hasSchoolKey;
            hasBossKey = GameObject.FindGameObjectWithTag("Preserve").GetComponent<Preserve>().hasBossKey;
            hasDied = GameObject.FindGameObjectWithTag("Preserve").GetComponent<Preserve>().deathload;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, v, 0f);
        if (Input.GetKey(KeyCode.LeftShift))
            movement = movement.normalized * runSpeed * Time.deltaTime;
        else
            movement = movement.normalized * walkSpeed * Time.deltaTime;
        rigidBody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerToMouse = mousePosVector - transform.position;
        playerToMouse.z = 0f;
        if (Mathf.Abs(playerToMouse.y) >= Mathf.Abs(playerToMouse.x))
        {
            if (playerToMouse.y <= 0)
                direction = FacingDirection.Front;
            else direction = FacingDirection.Back;
        }
        else
        {
            if (playerToMouse.x <= 0)
                direction = FacingDirection.Left;
            else direction = FacingDirection.Right;
        }
    }

    void Animating(float h, float v)
    {
        bool isMoving = h != 0f || v != 0f;
        if(isMoving && !wasMoving)
            anim.SetBool("IsMoving", true);
        else if (!isMoving && wasMoving)
            anim.SetBool("IsMoving", false);
        if(direction != prevDirection)
            anim.SetInteger("Direction", (int)direction);
        wasMoving = isMoving;
        prevDirection = direction;
    }

    public override void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        //playerAudio.Play();
        if (currentHealth <= 0)
            Death();
    }

    protected override void Death()
    {
        //playerShooting.DisableEffects();
        //anim.SetTrigger("Die");
        //playerAudio.clip = deathClip;
        //playerAudio.Play();
        playerAttack.enabled = false;
        this.enabled = false;
        GameObject.FindGameObjectWithTag("Preserve").GetComponent<Preserve>().deathload = true;
        //Destroy(gameObject, 1f);
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void PickupKey(string keyType)
    {
        if (keyType == "WaterKey")
            hasWaterKey = true;
        else if (keyType == "SchoolKey")
            hasSchoolKey = true;
        else if (keyType == "BossKey")
            hasBossKey = true;
        audioSource.clip = pickupSound;
        audioSource.Play();
    }
}
