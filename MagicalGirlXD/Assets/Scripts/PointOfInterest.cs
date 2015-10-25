using UnityEngine;
using System.Collections.Generic;

public class PointOfInterest : MonoBehaviour {

	// Use this for initialization
    public bool front = false;
    public bool back = false;
    public bool left = false;
    public bool right = false;

    public float restTime = 0f;
    public float rotationSpeed = 0f;

    public bool waitUntilNextEnemy = false;

    public List<FacingDirection> directionPattern;

    void Awake()
    {
        //initialize the direction pattern
        if (front)
            directionPattern.Add(FacingDirection.Front);
        if (right)
            directionPattern.Add(FacingDirection.Right);
        if (back)
            directionPattern.Add(FacingDirection.Back);
        if (left)
            directionPattern.Add(FacingDirection.Left);
    }

    /// <summary>
    /// When an enemy enters the poi, tell the enemy they reached their destination
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().DestinationReached();
        }
    }
}
