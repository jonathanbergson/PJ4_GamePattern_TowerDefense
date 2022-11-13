using UnityEngine;

namespace Bullet
{
    public class BulletSimple : IBulletBehaviour
    {
        private const float Speed = 14f;

        public void Move(Transform transform, Vector3 direction)
        {
            transform.Translate(direction * Speed * Time.deltaTime);
        }
    }
}
