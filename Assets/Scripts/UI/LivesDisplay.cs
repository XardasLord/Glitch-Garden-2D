using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class LivesDisplay : MonoBehaviour
    {
        [SerializeField] private int lives = 5;

        private Text _liveText;

        private void Start()
        {
            _liveText = GetComponent<Text>();
            UpdateDisplay();

            DamageCollider.OnEnemyEntered += TakeLife;
        }

        private void OnDestroy() 
            => DamageCollider.OnEnemyEntered -= TakeLife;

        public void TakeLife()
        {
            lives--;
            UpdateDisplay();

            if (lives <= 0)
                FindObjectOfType<LevelController>().HandleLoseCondition();
        }

        private void UpdateDisplay() 
            => _liveText.text = lives.ToString();
    }
}