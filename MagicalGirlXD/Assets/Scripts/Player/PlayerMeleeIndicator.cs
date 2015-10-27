using UnityEngine;
using System.Collections;

public class PlayerMeleeIndicator : MonoBehaviour {
    float timer;
    float duration;
    GameObject playerObject;
    Player player;
    SpriteRenderer indicator;

	void Awake() {
        duration = 0.25f;
        timer = duration;
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Player>();
        indicator = GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate() {
        if (timer >= duration) indicator.enabled = false;
        else timer += Time.deltaTime;
	}

    public void SetRotation(Vector3 vector)
    {
        float angle = Mathf.Atan(vector.y/vector.x)*Mathf.Rad2Deg;

        if (vector.x < 0 && vector.y > 0)
            angle += 180;
        else if (vector.x < 0 && vector.y < 0)
            angle -= 180;

        indicator.enabled = true;
        indicator.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        timer = 0;
    }
}
