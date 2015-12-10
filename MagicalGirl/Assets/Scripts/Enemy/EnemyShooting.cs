using UnityEngine;
using System.Collections;

public class EnemyShooting : EnemyAttack
{
    public float range = 150f;
    public Transform shotPrefab;
    Enemy manager;

    void Awake()
    {
        manager = transform.parent.GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        manager.OnChildTriggerEnter(name, other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        manager.OnChildTriggerEnter(name, other);
    }

    public override void Attack(GameObject player)
    {
        var shotTransform = Instantiate(shotPrefab) as Transform;
        shotTransform.position = transform.position;
        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            shot.isEnemyShot = true;
            shot.direction = player.transform.position - transform.position;
            shot.direction.z = 0f;
            shot.direction.Normalize();
        }
    }

    public override float GetRange()
    {
        return range;
    }
}
