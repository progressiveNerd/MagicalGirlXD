using UnityEngine;
using System.Collections;

public abstract class EnemyAttack : MonoBehaviour {
    public abstract float GetRange();
    public abstract void Attack(GameObject player);
}
