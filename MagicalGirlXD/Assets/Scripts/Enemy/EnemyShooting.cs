using UnityEngine;
using System.Collections;

public class EnemyShooting : EnemyAttack {
    public Transform shotPrefab;
    Enemy manager;

    void Awake() {
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        //anim = GetComponent<Animator>();
        range = 100f;
        manager = transform.parent.GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        manager.OnChildTriggerEnter(name, other);
    }

    void OnTriggerExit2D(Collider2D other) {
        manager.OnChildTriggerEnter(name, other);
    }

    public override void Attack(GameObject player) {
        var shotTransform = Instantiate(shotPrefab) as Transform;
        shotTransform.position = transform.position;
        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
        if (shot != null) {
            shot.isEnemyShot = true;
            shot.direction = player.transform.position - transform.position;
            shot.direction.z = 0f;
            shot.direction.Normalize();
        }
    }
}
