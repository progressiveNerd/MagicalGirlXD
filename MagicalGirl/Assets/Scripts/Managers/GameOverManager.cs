using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public Player player;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player.currentHealth <= 0)
            anim.SetTrigger("GameOver");
    }
}
