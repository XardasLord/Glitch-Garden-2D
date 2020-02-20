using System;
using UnityEngine;

namespace Defenders
{
    public class Projectile : MonoBehaviour
    {
        public event Action OnDestroy = delegate { }; 

        private void Awake()
        {
            GetComponent<ProjectileDamage>().OnHit += Hit;
        }

        private void Hit()
        {
            Destroy(gameObject);
            OnDestroy();
        }
    }
}
