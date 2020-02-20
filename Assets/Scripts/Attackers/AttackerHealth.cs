using System;
using UnityEngine;

namespace Attackers
{
    public class AttackerHealth : MonoBehaviour
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
