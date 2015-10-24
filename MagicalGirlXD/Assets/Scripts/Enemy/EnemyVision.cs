using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour
{

    Enemy manager;
    bool seen;

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
