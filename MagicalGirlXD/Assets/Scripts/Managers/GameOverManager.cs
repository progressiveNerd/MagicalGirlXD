using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth health;

    Animator anim;

	void Awake () 
    {
        anim = GetComponent<Animator>();
	}
	
	void Update () 
    {
	    if(health.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }
	}
}
