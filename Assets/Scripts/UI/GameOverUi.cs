using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOverUi : MonoBehaviour
    {
        private static readonly int ShowKey = Animator.StringToHash("show");
        [SerializeField] private PointsManager points;
        [SerializeField] private TextMeshProUGUI pointsText;
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerInput input;

        private void Awake()
        {
            input.enabled = false;
        }

        public void Show()
        {
            pointsText.text = points.CurrentPoints.ToString();
            animator.SetTrigger(ShowKey);
        }

        public void EnableRestartInput()
        {
            input.enabled = true;
        }

        private void OnJump()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}