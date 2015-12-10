using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour
{
    Enemy manager;

    void Awake()
    {
        manager = transform.parent.GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        manager.OnChildTriggerEnter(name, other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        manager.OnChildTriggerExit(name, other);
    }
}
