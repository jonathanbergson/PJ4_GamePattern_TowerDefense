using UnityEngine;

namespace Turret
{
    public class Turret : MonoBehaviour
    {
        public static Turret Instance;

        [SerializeField] private int life = 10;

        private void Awake()
        {
            Instance = this;
        }
    }
}
