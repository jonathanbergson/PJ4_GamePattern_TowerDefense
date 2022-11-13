using UnityEngine;

namespace Bullet
{
    public class BulletExplosive : IBulletBehaviour
    {
        private const float Speed = 5f;

        public void Move(Transform transform, Vector3 direction)
        {
            direction.y = Mathf.Sin(Time.time * 20);
            transform.position += direction * Speed * Time.deltaTime;
        }
    }
}
