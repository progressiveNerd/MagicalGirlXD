using UnityEngine;
using System.Collections;

public class AreaSwitch : MonoBehaviour
{
    Player player;
    public GameObject preserved;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        preserved = GameObject.FindWithTag("Preserve");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            preserved.GetComponent<Preserve>().setPosition(player.transform.position);
            preserved.GetComponent<Preserve>().toggleLoad();

            if (Application.loadedLevel == 3)
                Application.LoadLevel(1);
            if (player.hasWaterKey)
            {
                if (Application.loadedLevel == 1 && ((player.transform.position.x >= 14 && player.transform.position.x <= 24)
                                                     || (player.transform.position.x >= 58 && player.transform.position.x <= 69)))
                    Application.LoadLevel(2);
                else if (Application.loadedLevel == 2 && ((player.transform.position.x >= 10 && player.transform.position.x <= 24)
                                                          || (player.transform.position.x >= 78 && player.transform.position.x <= 93)))
                    Application.LoadLevel(1);
            }
            if (player.hasSchoolKey)
            {
                if (Application.loadedLevel == 1 && ((player.transform.position.x >= 40 && player.transform.position.x <= 42)))
                    Application.LoadLevel(5);
                else if (Application.loadedLevel == 2 && ((player.transform.position.x >= 46 && player.transform.position.x <= 56)))
                    Application.LoadLevel(5);
                else if (Application.loadedLevel == 5 && ((player.transform.position.x >= 23 && player.transform.position.x <= 26 && player.transform.position.y >= 42)))
                    Application.LoadLevel(2);
                else if (Application.loadedLevel == 5 && ((player.transform.position.x >= 23 && player.transform.position.x <= 26 && player.transform.position.y <= 7)))
                    Application.LoadLevel(1);
            }
            if (player.hasBossKey)
            {
                if (Application.loadedLevel == 5 && ((player.transform.position.x >= 39 && player.transform.position.x <= 42)))
                    Application.LoadLevel(4);
                else if (Application.loadedLevel == 5 && ((player.transform.position.x >= 7 && player.transform.position.x <= 10)))
                    Application.LoadLevel(4);
            }
        }
    }
}
