using System;
using Attackers;
using UnityEngine;

namespace Defenders
{
    public class ProjectileDamage : MonoBehaviour
    {
        [SerializeField] private int damageValue = 100;

        public event Action<int> OnDealDamage = delegate { };

        public int Damage { get; private set; }

        private void Awake()
        {
            Damage = damageValue;
        }

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            //TODO: Fire an event!
            //OnDealDamage(Damage);

            otherCollider.GetComponent<AttackerHealth>().DealDamage(Damage);
        }
    }
}
