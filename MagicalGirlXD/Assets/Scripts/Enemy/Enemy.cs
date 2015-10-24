using UnityEngine;
using System.Collections;

public class Enemy : Entity
{
    //player vars
    GameObject player;
    PlayerHealth playerHealth;

    //enemy info vars
    public int startingHealth = 2;
    int enemyHealth;
    public bool ranged;
    EnemyAttack attackScript;
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    Animator anim;
    BoxCollider boxCollider;
    bool isDead;

    //stealth vars
    bool alerted;

    //enemy movement vars
    public float walkSpeed = 6f;
    public float chaseSpeed = 12f;
    PointOfInterest[] points;
    PointOfInterest current;
    Vector2 movement;
    Rigidbody2D enemyRigidbody;
    public FacingDirection direction = FacingDirection.Front;
    float poiTimer;
    float turnTimer;
    bool destinationReached;

    //attack vars
    bool playerInRange;
    float attackTimer;

    //public bool playerInRange;
    //public bool seen = false;
    //public float timeBetweenAttacks = 0.5f;
    //public int attackDamage = 10;
    //float timer;
    //public int poiNext = 0;


    //GameObject player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    //public bool destinationReached = false;
    //public PointOfInterest[] points;

    // Use this for initialization
    void Awake()
    {
        enemyHealth = startingHealth;
        attackTimer = 0f;
        poiTimer = 0f;
        turnTimer = 0f;
        destinationReached = false;
        alerted = false;
        playerInRange = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        attackTimer += Time.deltaTime;
        poiTimer += Time.deltaTime;

        //attack update
        if (attackTimer >= timeBetweenAttacks && playerInRange && enemyHealth > 0)
            Attack();
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }

        //movement update
        if (!alerted)
        {

            nextPoint = manager.points[manager.poiNext];
            float h = nextPoint.transform.position.x;
            float v = nextPoint.transform.position.z;
            if ((transform.position.x == nextPoint.transform.position.x))
            {
                destinationReached = true;
                Patrol();
            }

            Move(h - transform.position.x, v - transform.position.z);
        }
        else
        {
            Move(player.transform.position.x - transform.position.x, player.transform.position.z - transform.position.z);
        }
    }

    public void OnChildTriggerEnter(string aName, Collider aOther)
    {
        Debug.Log(aOther.name + " collided with " + aName);


        //do stuff here
    }

    public void OnChildTriggerExit(string aName, Collider aOther)
    {
        Debug.Log(aOther.name + " exited " + aName);

        //if (aName == "EnemyMelee" && aOther.name == "Player")
        //{
        //    playerInRange = false;
        //}
        //else if (aName == "EnemyVision" && aOther.name == "Player")
        //{
        //    Patrol();
        //}
    }

    void Attack()
    {
        attackTimer = 0f;
        if (playerHealth.currentHealth > 0)
            playerHealth.TakeDamage(attackDamage);
    }

    void Move(float h, float v)
    {
        movement.Set(h, v);
        movement = movement.normalized * walkSpeed * Time.deltaTime;
        //        enemyRigidBody.MovePosition(transform.position + movement);
    }

    public void Patrol()
    {
        //if (destinationReached)
        //{
        //    if (poiNext < 9)
        //    {
        //        poiNext++;
        //        destinationReached = false;
        //    }
        //    else
        //    {
        //        poiNext = 0;
        //        destinationReached = false;
        //    }
        //}
    }

    void Death()
    {
        isDead = true;
        boxCollider.isTrigger = true;
        //anim.SetTrigger ("Dead");
        //enemyAudio.clip = deathClip;
        //enemyAudio.Play ();
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("stirng");
        if (isDead)
            return;
        //enemyAudio.Play ();
        enemyHealth -= amount;
        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();
        if (enemyHealth <= 0)
            Destroy(gameObject, 0f);
    }

    void Turn()
    {
        int size = current.directionPattern.Length;
        for(int i = 0; i < size; i++)
        {

        }
    }
}
