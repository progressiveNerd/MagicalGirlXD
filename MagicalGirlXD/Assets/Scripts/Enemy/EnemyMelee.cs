using UnityEngine;
using System.Collections;

public class EnemyMelee : EnemyAttack {
    Enemy manager;
    void Awake() {
        range = 1f;
        manager = transform.parent.GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        manager.OnChildTriggerEnter("Attack", other);
    }

    void OnTriggerExit2D(Collider2D other) {
        manager.OnChildTriggerExit("Attack", other);
    }

    public override void Attack(GameObject player) {
        Debug.Log("Attacking!");
    }
}
