using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    Player player;
    GameObject confirm;
    public int scene;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.Equals(player.GetComponent<BoxCollider2D>()))
            Application.LoadLevel(scene);
    }
}
