using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public Player player;
    private bool isShowing = false;
    public GameObject menu;
    private bool isDead = false;

    void Update()
    {
        if (!isDead)
            if (player.currentHealth <= 0)
            {
                isShowing = !isShowing;
                menu.SetActive(isShowing);
                isDead = true;
            }
    }
}
