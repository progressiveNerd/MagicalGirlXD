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

    public FacingDirection[] directionPattern;

    void Awake()
    {
        //initialize the direction pattern
        Queue<FacingDirection> temp = new Queue<FacingDirection>();
        if (front)
            temp.Enqueue(FacingDirection.Front);
        if (right)
            temp.Enqueue(FacingDirection.Right);
        if (back)
            temp.Enqueue(FacingDirection.Back);
        if (left)
            temp.Enqueue(FacingDirection.Left);

        directionPattern = temp.ToArray();
    }
}
