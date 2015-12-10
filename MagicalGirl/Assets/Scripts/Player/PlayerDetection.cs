using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour {
    public float growthRate = 1f;
    public float decayRate = 0.5f;
    public float minimumRadius = 1f;
    public float maximumRadius = 75;
    public AudioClip detectionSound;
	public AudioClip stealthedSound;

    bool detected;
    float radius;
    int detectionCounter;
    AudioSource audioSource;
    CircleCollider2D detectionCollider;

    void Awake() {
        radius = minimumRadius;
        detectionCounter = 0;
        audioSource = GetComponentInParent<AudioSource>();
        detectionCollider = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate() {
        if (detectionCounter > 0 && radius < maximumRadius)
            radius += growthRate * Time.deltaTime;
        else if(radius > minimumRadius)
            radius -= decayRate * Time.deltaTime;
        detectionCollider.radius = radius;
    }

    public void Detect() {
        detectionCounter++;
        //if(detectionCounter == 1)
            //audioSource.clip = detectionSound;
			//audioSource.Play();
    }

    public void Undetect() {
        detectionCounter--;
		//if(detectionCounter == 0)
			//audioSource.clip = stealthedSound;
			//audioSource.Play();
    }
}
