using System;
using UnityEngine;

namespace Defenders
{
    public class DefenderHealth : MonoBehaviour
    {
        [SerializeField] private int health = 100;

        public event Action OnDied = delegate { };

        public void DealDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                OnDied();
                Destroy(gameObject);
            }
        }
    }
}
