using System;
using UnityEngine;

namespace Defenders
{
    public class DefenderSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject defender;

        public event Action DefenderSpawned = delegate { };

        private void OnMouseDown()
        {
            SpawnDefender();
        }

        private void SpawnDefender()
        {
            var newDefender = Instantiate(defender, transform.position, Quaternion.identity);
            DefenderSpawned();
        }
    }
}
