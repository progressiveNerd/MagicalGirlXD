using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour
{
    public abstract void TakeDamage(int amount);
    protected abstract void Death();
}
