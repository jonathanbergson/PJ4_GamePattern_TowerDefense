using UnityEngine;

namespace Tower
{
    public class Tower : MonoBehaviour
    {
        public static Tower Instance;

        [SerializeField] private int life = 10;

        private void Awake()
        {
            Instance = this;
        }
    }
}
