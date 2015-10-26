using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    LevelManager levelManager;
    
    //stealth vars
    bool alerted;

    //enemy movement vars
    public float walkSpeed = 2f;
    public float chaseSpeed = 3.5f;
    public FacingDirection direction = FacingDirection.Front;
    public List<PointOfInterest> points;

    public bool destinationReached;
    public float poiTimer;
    public float turnTimer;
    FacingDirection playerDirection;
    CircleCollider2D attackRangeCollider;
    EnemyIndicator directionIndicator;
    List<PointOfInterest>.Enumerator currentPOI;
    List<FacingDirection>.Enumerator currentRotation;
    Rigidbody2D enemyRigidbody;
    Vector3 movement;

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
        attackRangeCollider = attackScript.gameObject.GetComponent<CircleCollider2D>();
        attackRangeCollider.radius = attackScript.range;
        anim = GetComponent<Animator>();
        levelManager = GetComponent<LevelManager>();
        points = new List<PointOfInterest>();
        directionIndicator = GetComponentInChildren<EnemyIndicator>();
    }

    void FixedUpdate() {
        // if we haven't set up the enumerator, do so
        if(currentPOI.Current == null) {
            currentPOI = points.GetEnumerator();
            currentPOI.MoveNext(); //set the enumerator to the first element (Why microsoft?)
            Debug.Log(currentPOI.Current);
            currentRotation = currentPOI.Current.directionPattern.GetEnumerator();
            currentRotation.MoveNext(); //why
        }

        // get the player's direction relative to the enemy if they're within range
        if (alerted) {
            Vector3 playerVector = player.transform.position - transform.position;
            playerVector.z = 0f;
            if (Mathf.Abs(playerVector.y) >= Mathf.Abs(playerVector.x)) {
                if (playerVector.y <= 0)
                    playerDirection = FacingDirection.Front;
                else playerDirection = FacingDirection.Back;
            }
            else {
                if (playerVector.x <= 0)
                    playerDirection = FacingDirection.Left;
                else playerDirection = FacingDirection.Right;
            }
        }

        if(playerDirection == direction && alerted)
            player.GetComponentInChildren<PlayerDetection>().Detect();

        attackTimer += Time.deltaTime;

        //attack update
        if (playerScript.currentHealth <= 0) {
            alerted = false;
            playerInRange = false;
            //anim.SetTrigger("PlayerDead");
        }
        if (attackTimer >= timeBetweenAttacks && playerInRange && alerted && playerDirection == direction && currentHealth > 0) {
            attackTimer = 0f;
            attackScript.Attack(player);
        }

        //movement update
        if (!alerted)
        {
            if (destinationReached)
            { //if you are waiting at a POI
                poiTimer += Time.deltaTime;
                turnTimer += Time.deltaTime;
                if (turnTimer >= currentPOI.Current.rotationSpeed)
                    Turn();
                if (poiTimer >= currentPOI.Current.restTime)
                {
                    if (!currentPOI.MoveNext())
                    { //if you reached the end of the list, restart.
                        currentPOI = points.GetEnumerator();
                        currentPOI.MoveNext(); // y
                        currentRotation = currentPOI.Current.directionPattern.GetEnumerator();
                        currentRotation.MoveNext(); // whyyy
                    }
                    Patrol();
                }
            }
            else //or travelling to a new POI
                Patrol();
        }
        else
        {
            if (!ranged && direction == playerDirection) //chase player
                Move(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

            Vector3 facing = player.transform.position - transform.position;
            facing.z = 0f;
            if (Mathf.Abs(facing.y) >= Mathf.Abs(facing.x))
            {
                if (facing.y <= 0)
                    direction = FacingDirection.Front;
                else direction = FacingDirection.Back;
            }
            else
            {
                if (facing.x <= 0)
                    direction = FacingDirection.Left;
                else direction = FacingDirection.Right;
            }
        }
        directionIndicator.SetDirection(direction);
    }

    public void OnChildTriggerEnter(string aName, Collider2D aOther) {
        if(aName == "Vision") {
            if (aOther.name == "Detection" && aOther.gameObject.tag == "Player") {
                alerted = true;
            }
        } else if (aName == "Attack") {
            if (aOther.name == "Player")
                playerInRange = true;
        }
    }

    public void OnChildTriggerExit(string aName, Collider2D aOther) {
        if (aName == "Vision") {
            if (aOther is CircleCollider2D && aOther.gameObject.tag == "Player") {
                alerted = false;
                player.GetComponentInChildren<PlayerDetection>().Undetect();
            }
        } else if (aName == "Attack") {
            if (aOther.name == "Player")
                playerInRange = false;
        }
    }

    void Move(float h, float v) {
        movement.Set(h, v, 0f);
        movement = movement.normalized * walkSpeed * Time.deltaTime;
        enemyRigidbody.MovePosition(this.gameObject.transform.position + movement);
    }

    public void Patrol() {
        poiTimer = 0f;
        if(!ranged)
            destinationReached = false;

        float h = currentPOI.Current.gameObject.transform.position.x;
        float v = currentPOI.Current.gameObject.transform.position.y;
        Move(h - transform.position.x, v - transform.position.y);

        Vector3 facing = currentPOI.Current.gameObject.transform.position - transform.position;
        facing.z = 0f;
        if (Mathf.Abs(facing.y) >= Mathf.Abs(facing.x)) {
            if (facing.y <= 0)
                direction = FacingDirection.Front;
            else direction = FacingDirection.Back;
        }
        else {
            if (facing.x <= 0)
                direction = FacingDirection.Left;
            else direction = FacingDirection.Right;
        }
    }

    void Death() {
        isDead = true;
        //levelManager.EnemyDead();
        if(alerted)
            player.GetComponentInChildren<PlayerDetection>().Undetect();
        Destroy(gameObject, 0f);
    }

    public void TakeDamage(int amount) {
        if (isDead)
            return;
        currentHealth -= amount;
        if (currentHealth <= 0)
            Death();
    }

    void Turn() {
        direction = currentRotation.Current;
        if(!currentRotation.MoveNext()) {
            currentRotation = currentPOI.Current.directionPattern.GetEnumerator();
            currentRotation.MoveNext();
        }
        turnTimer = 0f;
    }

    public void DestinationReached() {
        destinationReached = true;
    }
}
