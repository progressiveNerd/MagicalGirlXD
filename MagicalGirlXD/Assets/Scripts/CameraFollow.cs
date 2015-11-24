using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;
	
	void Start() {
        offset = transform.position - target.position;
	}

	void Update() {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing + Time.deltaTime);
    }

	public void ChangePosition(Vector3 a) {
		transform.position = a;
	}
}
