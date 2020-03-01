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
            SpawnDefender(GetSquareClicked());
        }

        private static Vector2 GetSquareClicked()
        {
            var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            var worldPos = Camera.main.ScreenToWorldPoint(clickPos);

            return worldPos;
        }

        private void SpawnDefender(Vector2 worldPos)
        {
            Instantiate(defender, worldPos, Quaternion.identity);
            DefenderSpawned();
        }
    }
}
