using UnityEngine;

namespace Defenders
{
    public class DefenderShooter : MonoBehaviour
    {
        [SerializeField] private GameObject projectile, gunPosition;

        public void Fire()
        {
            Instantiate(projectile, gunPosition.transform.position, Quaternion.identity);
        }
    }
}
