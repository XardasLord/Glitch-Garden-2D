using System.Globalization;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class LivesDisplay : MonoBehaviour
    {
        [SerializeField] private float baseLives = 3;

        private float _lives;
        private Text _liveText;

        private void Start()
        {
            _lives = baseLives - PlayerPrefsController.GetDifficulty();
            _liveText = GetComponent<Text>();
            UpdateDisplay();

            DamageCollider.OnEnemyEntered += TakeLife;
        }

        private void OnDestroy() 
            => DamageCollider.OnEnemyEntered -= TakeLife;

        public void TakeLife()
        {
            _lives--;
            UpdateDisplay();

            if (_lives <= 0)
                FindObjectOfType<LevelController>().HandleLoseCondition();
        }

        private void UpdateDisplay() 
            => _liveText.text = _lives.ToString(CultureInfo.InvariantCulture);
    }
}