using UnityEngine;
using System.Collections;

public class EnemyMelee : MonoBehaviour
{	
    EnemyManager manager;
	void Awake ()
	{
		//anim = GetComponent <Animator> ();
        manager = transform.parent.GetComponent<EnemyManager>();
	}
	
	
	void OnTriggerEnter (Collider other)
	{
        //if(other == playerDamage)
        //    playerInRange = true;
        manager.OnChildTriggerEnter(name, other);
	}
	
	
	void OnTriggerExit (Collider other)
	{
        manager.OnChildTriggerExit(name, other);
	}
}
