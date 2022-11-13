using UnityEngine;

namespace Bullet
{
    public class BulletMovement : MonoBehaviour
    {
        private IBulletBehaviour _bulletBehaviour;
        private Vector3 _direction;

        private void Start()
        {
            Destroy(gameObject, 3f);
        }

        private void Update()
        {
            _bulletBehaviour?.Move(transform, _direction);
        }

        public void SetBehaviour(IBulletBehaviour type, Vector3 direction)
        {
            _bulletBehaviour = type;
            _direction = direction;
        }
    }
}
