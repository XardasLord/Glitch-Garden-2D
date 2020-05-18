using System.Collections;
using UnityEngine;

namespace Attackers
{
    public class AttackerSpawner : MonoBehaviour
    {
        [SerializeField] private float minSpawnDelay = 1f;
        [SerializeField] private float maxSpawnDelay = 5f;
        [SerializeField] private Attacker[] attackerPrefabs;

        private bool _spawn = true;

        private IEnumerator Start()
        {
            while (_spawn)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                SpawnAttacker();
            }
        }

        private void SpawnAttacker()
        {
            var attackerIndex = Random.Range(0, attackerPrefabs.Length);
            Spawn(attackerPrefabs[attackerIndex]);
        }

        private void Spawn(Attacker attacker)
        {
            var newAttacker = Instantiate(attacker, transform.position, Quaternion.identity);
            newAttacker.transform.parent = transform;
        }
    }
}
