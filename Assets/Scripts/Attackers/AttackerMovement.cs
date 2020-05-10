using UnityEngine;

namespace Attackers
{
    public class AttackerMovement : MonoBehaviour
    {
        [SerializeField]
        [Range(0f, 5f)]
        private float currentSpeed = 1f;

        private GameObject _currentTarget;
        private static readonly int IsAttackingParameterId = Animator.StringToHash("IsAttacking");

        private void Update() 
            => Move();

        private void Move() 
            => transform.Translate(Vector2.left * (Time.deltaTime * currentSpeed));

        public void SetMovementSpeed(float speed) 
            => currentSpeed = speed;

        public void Attack(GameObject target)
        {
            GetComponent<Animator>().SetBool(IsAttackingParameterId, true);
            _currentTarget = target;
        }
    }
}
