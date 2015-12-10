using UnityEngine;
using System.Collections.Generic;

public class PointOfInterest : MonoBehaviour
{
    public float restTime = 0f;
    public float rotationSpeed = 0f;
    public bool waitUntilNextEnemy = false;
    public List<FacingDirection> directionPattern;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "MeleeEnemy(Clone)" || other.name == "RangedEnemy(Clone)")
            other.gameObject.GetComponent<Enemy>().DestinationReached();
    }
}
