using UnityEngine;

namespace Attackers
{
    public class AttackerMovement : MonoBehaviour
    {
        private float _currentSpeed = 1f;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector2.left * (Time.deltaTime * _currentSpeed));
        }

        public void SetMovementSpeed(float speed)
        {
            _currentSpeed = speed;
        }
    }
}
