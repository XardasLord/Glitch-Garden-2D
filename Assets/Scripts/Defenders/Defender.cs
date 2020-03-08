using UI;
using UnityEngine;

namespace Defenders
{
    public class Defender : MonoBehaviour
    {
        [SerializeField] private int starCost = 100;

        public void AddStars(int amount)
        {
            FindObjectOfType<StarDisplay>().AddStar(amount);
        }
    }
}
