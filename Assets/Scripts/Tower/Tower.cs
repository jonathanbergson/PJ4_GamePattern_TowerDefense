using UnityEngine;

namespace Tower
{
    public class Tower : MonoBehaviour
    {
        public static Tower Instance;

        [SerializeField] private int life = 10;
         int score = 0;

        private void Awake()
        {
            Instance = this;
        }

        public void LoseLifes()
        {
            life--;
            if (life <= 0)
                EndGame(false);
        }
        public void AddScore()
        {
            score++;
            if (score >= 10)
                EndGame(true);
        }
        void EndGame(bool state)
        {
            GameManager.Instance.winTheGame = state;
            GameManager.Instance.ChangeScene(2);
        }
    }
}
