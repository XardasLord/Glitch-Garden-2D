using UnityEngine;

namespace Attackers
{
    public class AttackerParticle : MonoBehaviour
    {
        [SerializeField] private GameObject dieParticleEffect;

        private void Awake()
        {
            GetComponent<AttackerHealth>().OnDied += DisplayDieParticleEffect;
        }

        private void DisplayDieParticleEffect()
        {
            var particle = Instantiate(dieParticleEffect, transform.position, Quaternion.identity);
            Destroy(particle, 1f);
        }
    }
}
