using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public enum FacingDirection {Front, Back, Left, Right};

    public float speed = 3f;
	public float runSpeed = 6f;
	public FacingDirection direction = FacingDirection.Front;

    Vector3 movement;
    //Animator anim;
    Rigidbody2D playerRigidBody;

    void Awake() {
        //anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v) {
        movement.Set(h, v, 0f);
		if(Input.GetKey(KeyCode.LeftShift))
			movement = movement.normalized * runSpeed * Time.deltaTime;
		else
        	movement = movement.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(transform.position + movement);
    }

    void Turning() {
        Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 playerToMouse = mousePosVector - transform.position;
		playerToMouse.z = 0f;
		if(Mathf.Abs(playerToMouse.y) >= Mathf.Abs(playerToMouse.x)) {
			if(playerToMouse.y <= 0)
				direction = FacingDirection.Back;
			else direction = FacingDirection.Front;
		} else {
			if(playerToMouse.x <= 0)
				direction = FacingDirection.Left;
			else direction = FacingDirection.Right;
		}
    }

    void Animating(float h, float v) {
        bool walking = h != 0f || v != 0f;
        //anim.SetBool("IsWalking", walking);
    }
}