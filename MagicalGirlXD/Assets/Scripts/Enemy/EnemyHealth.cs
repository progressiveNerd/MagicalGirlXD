﻿using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 2;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	//public int scoreValue = 10;
	//public AudioClip deathClip;
	
	//Animator anim;
	//AudioSource enemyAudio;
	//ParticleSystem hitParticles;
	BoxCollider boxCollider;
	bool isDead;
	bool isSinking;
	
	void Awake ()
	{
		//anim = GetComponent <Animator> ();
		//enemyAudio = GetComponent <AudioSource> ();
		//hitParticles = GetComponentInChildren <ParticleSystem> ();
		boxCollider = GetComponent<BoxCollider> ();
		currentHealth = startingHealth;
	}
	
	void Update() {
		if(isSinking)
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
	}
	
	public void TakeDamage(int amount) {
        Debug.Log("stirng");
		if(isDead)
			return;
		//enemyAudio.Play ();
		currentHealth -= amount;
		//hitParticles.transform.position = hitPoint;
		//hitParticles.Play();
		if(currentHealth <= 0)
			Destroy(gameObject, 0f);
	}
	
	void Death() {
		isDead = true;
		boxCollider.isTrigger = true;
		//anim.SetTrigger ("Dead");
		//enemyAudio.clip = deathClip;
		//enemyAudio.Play ();
	}
	
	public void StartSinking() {
		GetComponent <NavMeshAgent>().enabled = false;
		GetComponent <Rigidbody>().isKinematic = true;
		isSinking = true;
		//ScoreManager.score += scoreValue;
		Destroy (gameObject, 2f);
	}
}
