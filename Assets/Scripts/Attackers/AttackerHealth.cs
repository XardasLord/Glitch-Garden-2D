using UnityEngine;

namespace Assets.Scripts.Attackers
{
    public class AttackerHealth : MonoBehaviour
    {
        [SerializeField] private int health = 100;

        private void Awake()
        {
        }

        public void DealDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
