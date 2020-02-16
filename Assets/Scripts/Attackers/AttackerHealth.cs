using UnityEngine;

namespace Attackers
{
    public class AttackerHealth : MonoBehaviour
    {
        [SerializeField] private int health = 100;

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
