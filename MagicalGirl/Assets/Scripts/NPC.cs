using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    public int counter;
    public Canvas canvas;
    public Text text;
    bool encountered;
    bool isNpc1;
    public GameObject npc;

    void Start()
    {
        counter = 0;
        isNpc1 = false;
        text = canvas.GetComponentInChildren<Text>();
        if (npc.name.Equals("NPC"))
            isNpc1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (encountered)
            Cutscene();
        if (Input.GetKeyDown("enter") || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
            counter++;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            encountered = true;
            canvas.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            encountered = false;
            canvas.enabled = false;
        }
    }
    void Cutscene()
    {
        if (isNpc1)
        {
            if (counter == 0)
                text.text = "Help! The school has been taken over by monsters!";
            else if (counter == 1)
                text.text = "Move with the WASD keys!";
            else if (counter == 2)
                text.text = "Shoot enemies with the left mouse button";
            else if (counter == 3)
                text.text = "Proceed up this pathway to get to the school!";
            else if (counter == 4)
                text.text = "Look for keys to unlock the next area!";
            else if (counter == 5)
                text.text = "Good luck!! Show that Gym Teacher who's boss!";
        }
    }
}
