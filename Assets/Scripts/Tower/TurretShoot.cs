using Bullet;
using UnityEngine;

namespace Tower
{
    public class TurretShoot : MonoBehaviour
    {
        private float _timeRef;
        private float _frequency = 1f;
        private float _gizmoRange = 10f;

        [Header("Bullet")]
        [SerializeField] private BulletMovement bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private BulletTypes bulletType = BulletTypes.Explosive;

        [Header("Enemy")]
        [SerializeField] private Transform enemyTransform;

        private void Start()
        {
            _timeRef = Time.time + _frequency;
        }

        private void Update()
        {
            HandleChoiceEnemy();
            HandleChangeShootType();
            HandleShoot();
        }

        private void HandleChoiceEnemy()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.TagEnemy);
            GameObject enemyClose = null;
            float distanceToEnemyClose = Mathf.Infinity;

            foreach (var enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy < distanceToEnemyClose)
                {
                    distanceToEnemyClose = distanceToEnemy;
                    enemyClose = enemy;
                }
            }

            if (enemyClose != null && distanceToEnemyClose < _gizmoRange)
            {
                enemyTransform = enemyClose.transform;
            }
            else
            {
                enemyTransform = null;
            }
        }

        private void HandleChangeShootType()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                bulletType = BulletTypes.Explosive;
                SetupShootInfo();
                ClearTimeToShoot();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                bulletType = BulletTypes.Simple;
                SetupShootInfo();
                ClearTimeToShoot();
            }
        }

        private void SetupShootInfo()
        {
            switch (bulletType)
            {
                case BulletTypes.Explosive:
                    _frequency = 1f;
                    _gizmoRange = 30f;
                    break;
                case BulletTypes.Simple:
                default:
                    _frequency = 0.5f;
                    _gizmoRange = 14f;
                    break;
            }
        }

        private void HandleShoot()
        {
            if (Time.time >= _timeRef == false) return;

            if (enemyTransform)
            {
                InstantiateShoot();
                IncrementTimeToShoot();
            }
        }

        private void InstantiateShoot()
        {
            BulletMovement bullet = Instantiate(bulletPrefab, null);
            bullet.transform.position = bulletSpawnPoint.position;

            Vector3 enemyDirection = (enemyTransform.transform.position - bulletSpawnPoint.transform.position).normalized;

            switch (bulletType)
            {
                case BulletTypes.Explosive:
                    bullet.SetBehaviour(new BulletExplosive(), enemyDirection);
                    break;
                case BulletTypes.Simple:
                default:
                    bullet.SetBehaviour(new BulletSimple(), enemyDirection);
                    break;
            }
        }

        private void ClearTimeToShoot()
        {
            _timeRef = Time.time;
        }

        private void IncrementTimeToShoot()
        {
            _timeRef = Time.time + _frequency;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _gizmoRange);
        }
    }
}
