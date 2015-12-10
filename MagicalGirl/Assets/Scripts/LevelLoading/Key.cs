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
                player.PickupKey("SchoolKey");
                preserve.hasSchoolKey = true;
            }
            if (this.name == "WaterKey")
            {
                player.PickupKey("WaterKey");
                preserve.hasWaterKey = true;
            }
            if (this.name == "BossKey")
            {
                player.PickupKey("BossKey");
                preserve.hasBossKey = true;
            }
            Destroy(gameObject);
        }
    }
}
