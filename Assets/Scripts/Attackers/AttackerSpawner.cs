using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Attackers
{
    public class AttackerSpawner : MonoBehaviour
    {
        [SerializeField] private float minSpawnDelay = 1f;
        [SerializeField] private float maxSpawnDelay = 5f;
        [SerializeField] private Attacker[] attackerPrefabs;

        public event Action OnSpawned = delegate { };

        private bool _spawn = true;

        private IEnumerator Start()
        {
            while (_spawn)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                SpawnAttacker();
            }
        }

        public void StopSpawning()
            => _spawn = false;

        private void SpawnAttacker()
        {
            var attackerIndex = Random.Range(0, attackerPrefabs.Length);
            Spawn(attackerPrefabs[attackerIndex]);
        }

        private void Spawn(Attacker attacker)
        {
            var newAttacker = Instantiate(attacker, transform.position, Quaternion.identity);
            newAttacker.transform.parent = transform;
            OnSpawned();
        }
    }
}
