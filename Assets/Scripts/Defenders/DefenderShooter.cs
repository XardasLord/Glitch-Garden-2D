using Attackers;
using UnityEngine;

namespace Defenders
{
    public class DefenderShooter : MonoBehaviour
    {
        [SerializeField] private GameObject projectile, gunPosition;

        private AttackerSpawner _myLaneSpawner;
        private Animator _animator;
        private GameObject _projectileParent;

        private static readonly int IsAttackingParameterId = Animator.StringToHash("IsAttacking");
        private const string ProjectileParentName = "Projectiles";

        private void Awake()
            => _animator = GetComponent<Animator>();

        private void Start()
        {
            SetLaneSpawner();
            CreateProjectileParent();
        }

        private void CreateProjectileParent()
        {
            _projectileParent = GameObject.Find(ProjectileParentName);
            if (!_projectileParent)
            {
                _projectileParent = new GameObject(ProjectileParentName);
            }
        }

        private void Update() =>
            _animator.SetBool(IsAttackingParameterId, IsAttackerInLine());

        private void SetLaneSpawner()
        {
            var spawners = FindObjectsOfType<AttackerSpawner>();

            foreach (var spawner in spawners)
            {
                var isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;

                if (isCloseEnough)
                {
                    _myLaneSpawner = spawner;
                }
            }
        }

        private bool IsAttackerInLine()
            => _myLaneSpawner.transform.childCount > 0;

        public void Fire()
        {
            var newProjectile = Instantiate(projectile, gunPosition.transform.position, Quaternion.identity);
            newProjectile.transform.parent = _projectileParent.transform;
        }
    }
}
