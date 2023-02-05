using UI;
using UnityEngine;

namespace Player
{
    public class PlayerKiller : MonoBehaviour
    {
        [SerializeField] private PointsUi points;
        [SerializeField] private GameOverUi gameOver;

        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (GameState.GameIsOver)
            {
                return;
            }

            points.Hide();
            GameState.GameOver();
            gameOver.Show();
        }
    }
}