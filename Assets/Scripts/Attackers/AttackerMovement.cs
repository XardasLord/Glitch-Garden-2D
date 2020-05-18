using System;
using UnityEngine;

namespace Attackers
{
    public class AttackerMovement : MonoBehaviour
    {
        [SerializeField]
        [Range(0f, 5f)]
        private float currentSpeed = 1f;

        private Attacker _attackerComponent;

        private void Awake() => 
            _attackerComponent = GetComponent<Attacker>();

        private void Update()
        {
            Move();
            UpdateAnimationState();
        }

        private void Move() 
            => transform.Translate(Vector2.left * (Time.deltaTime * currentSpeed));

        public void SetMovementSpeed(float speed) 
            => currentSpeed = speed;

        private void UpdateAnimationState()
        {
            if (!_attackerComponent.IsAttacking)
            {
                _attackerComponent.StopAttack();
            }
        }
    }
}
