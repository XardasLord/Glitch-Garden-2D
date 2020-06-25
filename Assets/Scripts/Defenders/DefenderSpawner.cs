using System;
using UI;
using UnityEngine;

namespace Defenders
{
    public class DefenderSpawner : MonoBehaviour
    {
        private Defender _defender;
        private Camera _mainCamera;
        private StarDisplay _starDisplay;
        private GameObject _defenderParent;

        private const string DefenderParentName = "Defenders";

        public event Action DefenderSpawned = delegate { };

        private void Awake()
        {
            _mainCamera = Camera.main;
            _starDisplay = FindObjectOfType<StarDisplay>();
        }

        private void Start() 
            => CreateDefenderParent();

        private void CreateDefenderParent()
        {
            _defenderParent = GameObject.Find(DefenderParentName);
            if (!_defenderParent)
            {
                _defenderParent = new GameObject(DefenderParentName);
            }
        }

        private void OnMouseDown()
        {
            AttemptToPlaceDefenderAt(GetSquareClicked());
        }

        public void SetSelectedDefender(Defender defenderToSelect)
        {
            _defender = defenderToSelect;
        }

        private void AttemptToPlaceDefenderAt(Vector2 gridPos)
        {
            var defenderCost = _defender.GetStarCost();
            if (_starDisplay.HaveEnoughStars(defenderCost))
            {
                SpawnDefender(gridPos);
                _starDisplay.SpendStars(defenderCost);
            }
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
            var newDefender = Instantiate(_defender, worldPos, Quaternion.identity);
            newDefender.transform.parent = _defenderParent.transform;

            DefenderSpawned();
        }
    }
}
