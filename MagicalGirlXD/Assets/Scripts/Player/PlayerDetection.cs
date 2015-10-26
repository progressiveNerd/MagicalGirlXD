using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour {
    public float minimumRadius = 1f;
    public float growthRate = 1f;
    public float decayRate = 0.5f;
    bool detected;
    float radius;
    int detectionCounter;
    CircleCollider2D detectionCollider;

    void Awake()
    {
        radius = minimumRadius;
        detectionCounter = 0;
        detectionCollider = GetComponent<CircleCollider2D>();
        //manager = transform.parent.GetComponent<Player>();
    }

    void FixedUpdate()
    {
        if (detectionCounter > 0)
            radius += growthRate * Time.deltaTime;
        else if(radius > minimumRadius)
            radius -= decayRate * Time.deltaTime;
        detectionCollider.radius = radius;
    }

    public void Detect()
    {
        detectionCounter++;
    }

    public void Undetect()
    {
        detectionCounter--;
    }
}
