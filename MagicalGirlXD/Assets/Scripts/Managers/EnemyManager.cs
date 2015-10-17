using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    public bool playerInRange;
    public bool seen;
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    float timer;
    public int poiNext = 0;


    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    public bool destinationReached = false;
    public PointOfInterest[] points;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            Attack();
	}

    public void OnChildTriggerEnter(string aName, Collider aOther)
    {
        Debug.Log(aOther.name + " collided with " + aName);

        if(aName == "EnemyMelee" && aOther.name == "Player")
        {
            playerInRange = true;
            Swarm();
        }
        else if (aName == "EnemyVision" && aOther.name == "Player")
        {
            seen = true;
        }

        else if (aName == "EnemyMelee" && aOther.name =="PointOfInterest")
        {
            if (poiNext == 0)
            destinationReached = true;
            Patrol();
        }
        else if (aName == "EnemyVision" && aOther.name == "PointOfInterest (1)")
        {
            if (poiNext == 1)
            destinationReached = true;
            Patrol();
        }
        else if (aName == "EnemyVision" && aOther.name == "PointOfInterest (2)")
        {
            if (poiNext == 2)
            destinationReached = true;
            Patrol();
        }
        else if (aName == "EnemyVision" && aOther.name == "PointOfInterest (3)")
        {
            if(poiNext == 3)
                destinationReached = true;
            Patrol();
        }
        else if (aName == "EnemyVision" && aOther.name == "PointOfInterest (4)")
        {
            if (poiNext == 4)
            destinationReached = true;
            Patrol();
        }
        else if (aName == "EnemyVision" && aOther.name == "PointOfInterest (5)")
        {
            if (poiNext == 5)
                destinationReached = true;
            Patrol();
        }
        else if (aName == "EnemyVision" && aOther.name == "PointOfInterest (6)")
        {
            if (poiNext == 6)
                destinationReached = true;
            Patrol();
        }
        else if (aName == "EnemyVision" && aOther.name == "PointOfInterest (7)")
        {
            if (poiNext == 7)
                destinationReached = true;
            Patrol();
        }
        else if (aName == "EnemyVision" && aOther.name == "PointOfInterest (8)")
        {
            if (poiNext == 8)
                destinationReached = true;
            Patrol();
        }
        else if (aName == "EnemyVision" && aOther.name == "PointOfInterest (9)")
        {
            if (poiNext == 9)
                destinationReached = true;
            Patrol();
        }
        else if (aName == "EnemyVision" && aOther.name == "PointOfInterest (10)")
        {
            if (poiNext == 10)
                destinationReached = true;
            Patrol();
        }
    }
    public void OnChildTriggerExit(string aName, Collider aOther)
    {
        Debug.Log(aOther.name + " exited " + aName);

        if (aName == "EnemyMelee" && aOther.name == "Player")
        {
            playerInRange = false;
        }
        else if (aName == "EnemyVision" && aOther.name == "Player")
        {
            seen = false;
            Patrol();
        }
    }
    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
            playerHealth.TakeDamage(attackDamage);
    }

    public void Patrol()
    {
        if(destinationReached)
        {
            if (poiNext < 9)
            {
                poiNext++;
                destinationReached = false;
            }
            else
            {
                poiNext = 0;
                destinationReached = false;
            }
        }
    }

    public void Swarm()
    {

    }


}
