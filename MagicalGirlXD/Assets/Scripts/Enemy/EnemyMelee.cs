using UnityEngine;
using System.Collections;

public class EnemyMelee : EnemyAttack
{
    Enemy manager;
    void Awake()
    {
        manager = transform.parent.GetComponent<Enemy>();
    }


    void OnTriggerEnter(Collider other)
    {
        manager.OnChildTriggerEnter(name, other);
    }


    void OnTriggerExit(Collider other)
    {
        manager.OnChildTriggerExit(name, other);
    }
}
