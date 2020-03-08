using System;
using UnityEngine;

namespace Defenders
{
    public class DefenderSpawner : MonoBehaviour
    {
        private Defender _defender;

        private Camera _mainCamera;

        public event Action DefenderSpawned = delegate { };

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void OnMouseDown()
        {
            SpawnDefender(GetSquareClicked());
        }

        public void SetSelectedDefender(Defender defenderToSelect)
        {
            _defender = defenderToSelect;
        }

        private Vector2 GetSquareClicked()
        {
            var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            var worldPos = _mainCamera.ScreenToWorldPoint(clickPos);

            return SnapToGrid(worldPos);
        }

        private static Vector2 SnapToGrid(Vector2 rawWorldPos)
        {
            var newX = Mathf.RoundToInt(rawWorldPos.x);
            var newY = Mathf.RoundToInt(rawWorldPos.y);

            return new Vector2(newX, newY);
        }

        private void SpawnDefender(Vector2 worldPos)
        {
            Instantiate(_defender, worldPos, Quaternion.identity);
            DefenderSpawned();
        }
    }
}
