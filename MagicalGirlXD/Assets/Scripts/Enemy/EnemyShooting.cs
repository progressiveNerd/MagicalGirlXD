using UnityEngine;
using System.Collections;

public class EnemyShooting : EnemyAttack
{
    Enemy manager;

    //public float timeBetweenAttacks = 0.5f;
    //public int attackDamage = 10;


    //Animator anim;
    //GameObject player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    //bool playerInRange;
    //float timer;


    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        //anim = GetComponent<Animator>();
        manager = transform.parent.GetComponent<Enemy>();
    }


    void OnTriggerEnter(Collider other)
    {
        manager.OnChildTriggerEnter(name, other);
    }


    void OnTriggerExit(Collider other)
    {
        manager.OnChildTriggerEnter(name, other);
    }
}
