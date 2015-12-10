using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{
    public bool isEnemyShot = false;
    public float speed = 10f;
    public float range = 10f;
    public int damage = 1;
    public Vector3 direction;

    float elapsedDistance;
    BoxCollider2D shotCollider;
    Rigidbody2D body;
    Vector3 movement;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        shotCollider = GetComponent<BoxCollider2D>();
        elapsedDistance = 0;
    }

    void FixedUpdate()
    {
        movement = new Vector3(
            speed * direction.x * Time.deltaTime,
            speed * direction.y * Time.deltaTime, 0f);
        body.MovePosition(transform.position + movement);
        elapsedDistance += movement.magnitude;
        if (elapsedDistance >= range)
            Destroy(gameObject, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Entity target = other.gameObject.GetComponent<Entity>();
        if (target != null && ((target is Player && isEnemyShot) || (!(target is Player) && !isEnemyShot)))
        {
            target.TakeDamage(damage);
            if (shotCollider != null)
                shotCollider.enabled = false;
            Destroy(gameObject, 0.02f);
        }
        else if(other.tag == "Wall")
            Destroy(gameObject, 0f);
    }
}
