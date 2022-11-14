using UnityEngine;

namespace Bullet
{
    public interface IBulletBehaviour
    {
        public void Move(Transform transform, Vector3 direction);
        public void OnTriggerEnter(GameObject gameObject);
    }
}
