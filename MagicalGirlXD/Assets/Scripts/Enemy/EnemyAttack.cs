using UnityEngine;
using System.Collections;

public abstract class EnemyAttack : MonoBehaviour {
    public float range;
    public abstract void Attack(GameObject player);
}
