using Defenders;
using UnityEngine;

namespace Attackers
{
    public class Attacker : MonoBehaviour
    {
        private GameObject _currentTarget;
        private static readonly int IsAttackingParameterId = Animator.StringToHash("IsAttacking");

        public bool IsAttacking => _currentTarget != null;

        private void OnDestroy()
            => FindObjectOfType<LevelController>().AttackerKilled();

        public void Attack(GameObject target)
        {
            GetComponent<Animator>().SetBool(IsAttackingParameterId, true);
            _currentTarget = target;
        }

        public void StopAttack()
        {
            GetComponent<Animator>().SetBool(IsAttackingParameterId, false);
            _currentTarget = null;
        }

        public void StrikeCurrentTarget(int damage)
        {
            if (!_currentTarget) { return; }

            var health = _currentTarget.GetComponent<DefenderHealth>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }
}