using System;
using Attackers;
using UnityEngine;

namespace Defenders
{
    public class ProjectileDamage : MonoBehaviour
    {
        [SerializeField] private int damageValue = 100;

        public event Action OnHit = delegate { };

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            var attackerHealth = otherCollider.GetComponent<AttackerHealth>();
            var attacker = otherCollider.GetComponent<Attacker>();

            if (attacker && attackerHealth)
            {
                attackerHealth.DealDamage(damageValue);
                OnHit();
            }
        }
    }
}
