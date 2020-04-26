using System;
using Attackers;
using UnityEngine;

namespace Defenders
{
    public class DefenderShooter : MonoBehaviour
    {
        [SerializeField] private GameObject projectile, gunPosition;

        private AttackerSpawner _myLaneSpawner;

        private void Start()
        {
            SetLaneSpawner();
        }

        private void Update()
        {
            if (IsAttackerInLine())
            {
                Debug.Log("SHOOOT!");
            }
            else
            {
                Debug.Log("WAIT");
            }
        }
        private void SetLaneSpawner()
        {
            var spawners = FindObjectsOfType<AttackerSpawner>();

            foreach (var spawner in spawners)
            {
                var isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;

                if (isCloseEnough)
                {
                    _myLaneSpawner = spawner;
                }
            }
        }

        private bool IsAttackerInLine() 
            => _myLaneSpawner.transform.childCount > 0;

        public void Fire()
        {
            Instantiate(projectile, gunPosition.transform.position, Quaternion.identity);
        }
    }
}
