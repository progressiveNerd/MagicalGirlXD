using UnityEngine;
using System.Collections;

public class EnemyIndicator : MonoBehaviour {
    SpriteRenderer directionSprite;
	
	void Awake() {
	    directionSprite = GetComponent<SpriteRenderer>();
	}

    public void SetDirection(FacingDirection direction) {
        switch (direction) {
            case FacingDirection.Right:
                directionSprite.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
                break;
            case FacingDirection.Back:
                directionSprite.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
                break;
            case FacingDirection.Left:
                directionSprite.transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
                break;
            case FacingDirection.Front:
                directionSprite.transform.rotation = Quaternion.AngleAxis(270, Vector3.forward);
                break;
        }
    }
}
