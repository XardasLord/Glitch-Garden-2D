using Defenders;
using UnityEngine;

namespace UI
{
    public class DefenderMenuSelection : MonoBehaviour
    {
        [SerializeField] private Defender defenderPrefab;

        private SpriteRenderer _spriteRenderer;
        private DefenderMenuSelection[] _defenderMenuSelections;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _defenderMenuSelections = FindObjectsOfType<DefenderMenuSelection>();
        }
        
        private void OnMouseDown()
        {
            foreach (var defenderMenu in _defenderMenuSelections)
            {
                defenderMenu.GetComponent<SpriteRenderer>().color = new Color32(79, 79, 79, 255);
            }

            _spriteRenderer.color = Color.white;

            FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        }
    }
}
