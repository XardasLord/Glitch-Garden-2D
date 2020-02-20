using System.Collections;
using UnityEngine;

namespace Attackers
{
    public class AttackerSpawner : MonoBehaviour
    {
        [SerializeField] private float minSpawnDelay = 1f;
        [SerializeField] private float maxSpawnDelay = 5f;
        [SerializeField] private Attacker attackerPrefab;

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
            Instantiate(attackerPrefab, transform.position, Quaternion.identity);
        }
    }
}
