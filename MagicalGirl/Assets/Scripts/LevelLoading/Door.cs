using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public GameObject closedDoor;
    public GameObject openDoor;
    public Player playerscript;
    // Use this for initialization
    void Start()
    {
        playerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerscript.hasSchoolKey)
        {
            openDoor.SetActive(true);
            closedDoor.SetActive(false);
        }
        else
        {
            openDoor.SetActive(false);
            closedDoor.SetActive(true);
        }
    }
}
