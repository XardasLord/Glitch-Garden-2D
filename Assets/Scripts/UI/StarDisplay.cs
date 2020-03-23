using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class StarDisplay : MonoBehaviour
    {
        [SerializeField] private int stars = 100;

        private Text _starText;

        private void Start()
        {
            _starText = GetComponent<Text>();
            UpdateDisplay();
        }

        public bool HaveEnoughStars(int amount)
        {
            return stars >= amount;
        }

        public void AddStar(int amount)
        {
            stars += amount;
            UpdateDisplay();
        }

        public void SpendStars(int amount)
        {
            if (stars >= amount)
            {
                stars -= amount;
                UpdateDisplay();
            }
        }

        private void UpdateDisplay()
        {
            _starText.text = stars.ToString();
        }
    }
}
