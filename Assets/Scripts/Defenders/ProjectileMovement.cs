using UnityEngine;

namespace Assets.Scripts.Defenders
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
