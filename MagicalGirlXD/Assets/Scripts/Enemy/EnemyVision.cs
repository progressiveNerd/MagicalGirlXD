using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour {

    EnemyManager manager;
    
    void Awake()
    {
        manager = transform.parent.GetComponent<EnemyManager>();
    }

    void OnTriggerEnter (Collider other)
    {
        //if (other == playerCollider)
        //    seen = true;
        manager.OnChildTriggerEnter(name, other);
    }
    
    void OnTriggerExit (Collider other)
    {
        manager.OnChildTriggerExit(name, other);
    }
}
