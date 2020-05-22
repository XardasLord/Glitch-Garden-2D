using System;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public static event Action OnEnemyEntered = delegate { };

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        OnEnemyEntered();
    }
}