using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    //player vars
    GameObject player;
    Player playerScript;

    //enemy info vars
    public bool ranged;
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 1;
    public int startingHealth = 2;

    bool isDead;
    int currentHealth;
    Animator anim;
    EnemyAttack attackScript;
    
    //stealth vars
    bool alerted;

    //enemy movement vars
    public float walkSpeed = 3f;
    public float chaseSpeed = 5f;
    public FacingDirection direction = FacingDirection.Front;

    bool destinationReached;
    float poiTimer;
    float turnTimer;
    PointOfInterest[] points;
    PointOfInterest current;
    Rigidbody2D enemyRigidbody;
    Vector2 movement;

    //attack vars
    bool playerInRange;
    float attackTimer;

    void Awake() {
        currentHealth = startingHealth;
        attackTimer = 0f;
        poiTimer = 0f;
        turnTimer = 0f;
        destinationReached = false;
        alerted = false;
        playerInRange = false;

        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Player>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        if (ranged)
            attackScript = GetComponentInChildren<EnemyShooting>();
        else
            attackScript = GetComponentInChildren<EnemyMelee>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        attackTimer += Time.deltaTime;
        poiTimer += Time.deltaTime;

        //attack update
        if (playerScript.currentHealth <= 0) {
            alerted = false;
            playerInRange = false;
            //anim.SetTrigger("PlayerDead");
        }
        if (attackTimer >= timeBetweenAttacks && playerInRange && currentHealth > 0) {
            attackTimer = 0f;
            attackScript.Attack(player);
        }

        //movement update
        if (!alerted) {
            //nextPoint = manager.points[manager.poiNext];
            //float h = nextPoint.transform.position.x;
            //float v = nextPoint.transform.position.z;
            //if ((transform.position.x == nextPoint.transform.position.x)) {
            //    destinationReached = true;
                Patrol();
            //}

            //Move(h - transform.position.x, v - transform.position.z);
        } else {
            Move(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        }
    }

    public void OnChildTriggerEnter(string aName, Collider2D aOther) {
        if(aName == "Vision") {
            if(aOther.name == "Detection" && aOther.gameObject.tag == "Player")
                alerted = true;
        } else if (aName == "Attack") {
            if (aOther.name == "Player")
                playerInRange = true;
        }
    }

    public void OnChildTriggerExit(string aName, Collider2D aOther) {
        if (aName == "Vision") {
            if (aOther is CircleCollider2D && aOther.gameObject.tag == "Player")
                alerted = false;
        } else if (aName == "Attack") {
            if (aOther.name == "Player")
                playerInRange = false;
        }
    }

    void Move(float h, float v) {
        movement.Set(h, v);
        movement = movement.normalized * walkSpeed * Time.deltaTime;
        //        enemyRigidBody.MovePosition(transform.position + movement);
    }

    public void Patrol() {
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

    void Death() {
        isDead = true;
    }

    public void TakeDamage(int amount) {
        if (isDead)
            return;
        currentHealth -= amount;
        if (currentHealth <= 0)
            Destroy(gameObject, 0f);
    }

    void Turn() {
        int size = current.directionPattern.Length;
        for(int i = 0; i < size; i++)
        {

        }
    }
}
