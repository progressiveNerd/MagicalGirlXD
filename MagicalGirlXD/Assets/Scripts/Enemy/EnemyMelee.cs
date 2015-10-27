using UnityEngine;
using System.Collections;

public class EnemyMelee : EnemyAttack {
    public float range = 2f;
    public int damage = 1;
    Enemy manager;
    void Awake() {
        manager = transform.parent.GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        manager.OnChildTriggerEnter("Attack", other);
    }

    void OnTriggerExit2D(Collider2D other) {
        manager.OnChildTriggerExit("Attack", other);
    }

    public override void Attack(GameObject player) {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
            playerScript.TakeDamage(damage);
    }

    public override float GetRange() {
        return range;
    }
}
