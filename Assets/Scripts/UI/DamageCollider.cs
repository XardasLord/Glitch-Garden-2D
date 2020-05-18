using System;
using UnityEngine;

namespace UI
{
    public class DamageCollider : MonoBehaviour
    {
        public static event Action OnEnemyEntered = delegate { };

        private void OnTriggerEnter2D(Collider2D other)
            => OnEnemyEntered();
    }
}
