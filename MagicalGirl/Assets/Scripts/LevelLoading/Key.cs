using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{
    public Player player;
    public Preserve preserve;

    void Awake()
    {
        preserve = GameObject.FindGameObjectWithTag("Preserve").GetComponent<Preserve>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (this.name == "SchoolKey")
            {
                player.hasSchoolkey = true;
                preserve.hasSchoolKey = true;
            }
            if (this.name == "WaterKey")
            {
                player.hasWaterKey = true;
                preserve.hasWaterKey = true;
            }
            if (this.name == "BossKey")
            {
                player.hasBossKey = true;
                preserve.hasBossKey = true;
            }
            //audioSource.clip = pickupSound;
            //audioSource.Play();
            Destroy(gameObject);
        }
    }
}
