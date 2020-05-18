using Defenders;
using UnityEngine;

namespace Attackers
{
    public class Fox : MonoBehaviour
    {
        private static readonly int JumpTriggerParameterId = Animator.StringToHash("JumpTrigger");

        private Animator _animator;
        private Attacker _attacker;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _attacker = GetComponent<Attacker>();
        }

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            var otherObject = otherCollider.gameObject;

            if (otherObject.GetComponent<Gravestone>())
            {
                _animator.SetTrigger(JumpTriggerParameterId);
            }
            else if (otherCollider.GetComponent<Defender>())
            {
                _attacker.Attack(otherObject);
            }
        }
    }
}
