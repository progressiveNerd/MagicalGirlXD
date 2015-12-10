using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public string text;
    public Canvas textCanvas;
    public GameObject displayTextHere;
    Text t;
    bool playerInRange;

    void Awake()
    {
        textCanvas.enabled = false;
        t = textCanvas.GetComponentInChildren<Text>();
        playerInRange = false;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("enter")) && playerInRange) //player can turn ui on/off while in range
        {
            t.text = text;
            textCanvas.enabled = !textCanvas.enabled;
        }
        if (!playerInRange && textCanvas.enabled) //if the player leaves range of the object
            textCanvas.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Detection")
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Detection")
            playerInRange = false;
    }
}
