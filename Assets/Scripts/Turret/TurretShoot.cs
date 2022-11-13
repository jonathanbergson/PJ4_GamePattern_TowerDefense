using Bullet;
using UnityEngine;

namespace Turret
{
    public class TurretShoot : MonoBehaviour
    {
        private float _timeRef;
        [SerializeField] protected float frequency = 1f;

        [Header("Bullet")]
        [SerializeField] private BulletMovement bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private BulletTypes bulletType = BulletTypes.Simple;

        [Header("Enemie")] [SerializeField] private Transform enemyTransform;

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
            if (enemyTransform == null)
            {
                GameObject.FindGameObjectWithTag(Constants.TagEnemie);
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

            Shoot();
            IncrementTimeToShoot();
        }

        private void Shoot()
        {
            BulletMovement bullet = Instantiate(bulletPrefab, null);
            bullet.transform.position = bulletSpawnPoint.position;

            switch (bulletType)
            {
                case BulletTypes.Explosive:
                    frequency = 3.0f;
                    bullet.SetBehaviour(new BulletExplosive(), Vector3.forward);
                    break;
                case BulletTypes.Simple:
                default:
                    frequency = 0.5f;
                    bullet.SetBehaviour(new BulletSimple(), Vector3.forward);
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
    }
}
