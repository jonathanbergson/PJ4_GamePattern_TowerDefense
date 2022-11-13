using Bullet;
using UnityEngine;

namespace Tower
{
    public class TurretShoot : MonoBehaviour
    {
        private float _timeRef;
        [SerializeField] protected float frequency = 1f;
        [SerializeField] protected float gizmoRange = 10f;

        [Header("Bullet")]
        [SerializeField] private BulletMovement bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private BulletTypes bulletType = BulletTypes.Simple;

        [Header("Enemie")]
        [SerializeField] private Transform enemyTransform;

        private void Start()
        {
            _timeRef = Time.time + frequency;
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

            if (enemyClose != null && distanceToEnemyClose < gizmoRange)
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
                bulletType = BulletTypes.Simple;
                ClearTimeToShoot();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                bulletType = BulletTypes.Explosive;
                ClearTimeToShoot();
            }
        }

        private void HandleShoot()
        {
            if (Time.time >= _timeRef == false) return;

            if (enemyTransform) Shoot();
            IncrementTimeToShoot();
        }

        private void Shoot()
        {
            BulletMovement bullet = Instantiate(bulletPrefab, null);
            bullet.transform.position = bulletSpawnPoint.position;

            Vector3 enemyDirection = (enemyTransform.transform.position - bulletSpawnPoint.transform.position).normalized;

            switch (bulletType)
            {
                case BulletTypes.Explosive:
                    frequency = 3f;
                    gizmoRange = 5f;
                    bullet.SetBehaviour(new BulletExplosive(), enemyDirection);
                    break;
                case BulletTypes.Simple:
                default:
                    frequency = 0.5f;
                    gizmoRange = 10f;
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
            _timeRef = Time.time + frequency;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, gizmoRange);
        }
    }
}
