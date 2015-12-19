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
	public Image convoNPC;
	public Image convoPlayer;
	bool cutsceneCount; //keeps track of whether the player has gone through the cutscene.

    void Start()
    {
        counter = 0;
        isNpc1 = false;
        text = canvas.GetComponentInChildren<Text>();
		convoNPC.enabled = false;
		convoPlayer.enabled = false;
        if (npc.name.Equals("NPC"))
            isNpc1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (encountered) {
			Cutscene ();
			if (Input.GetKeyDown ("enter") || Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.E))
				counter++;
		}
		if (!encountered)
			counter = 0;
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
		if (!cutsceneCount) {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().enabled = false;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerAttack> ().enabled = false;
		}
        if (isNpc1) {
			if (counter == 0) {
				convoPlayer.enabled = false;
				convoNPC.enabled = true;
				text.text = "Help! The school has been taken over by monsters!";
			} else if (counter == 1) {
				convoNPC.enabled = false;
				convoPlayer.enabled = true;
				text.text = "Oh no! What can I do to help??!";
			} else if (counter == 2) {
				convoNPC.enabled = true;
				convoPlayer.enabled = false;
				text.text = "For starters, move with the W, A, S, and D keys!";
			} else if (counter == 3)
				text.text = "You can also shoot enemies with the left mouse button!";
			else if (counter == 4)
				text.text = "Proceed up this pathway to get to the school!";
			else if (counter == 5)
				text.text = "Look for keys to unlock the next area!";
			else if (counter == 6) {
				text.text = "Some dweeb dropped a key in the fountain and no one has picked it up!";
			}
			else if (counter == 7) {
				text.text = "Check that out first!";
			}
            else if (counter == 8) {
                //cutsceneCount = true;
                //GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().enabled = true;
                //GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerAttack> ().enabled = true;
				text.text = "Good luck!! Show that Gym Teacher who's boss!";
			}
            else if (counter == 9)
            {
                cutsceneCount = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().enabled = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().enabled = true;
                canvas.enabled = false;
            }
		} 
		else {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerAttack> ().enabled = true;
			if(counter == 0)
				text.text = "Hi! This area is currently off limits.";
			if(counter == 1)
				text.text = "It will be released as DLC for $1,000,000 in a few days!";

		}
    }
}
