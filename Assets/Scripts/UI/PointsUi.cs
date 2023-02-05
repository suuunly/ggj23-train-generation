using TMPro;
using UnityEngine;

namespace UI
{
    public class PointsUi : MonoBehaviour
    {
        private static readonly int HideKey = Animator.StringToHash("hide");
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Animator animator;

        public void UpdateScore(int amount)
        {
            text.text = amount.ToString();
        }

        public void Hide()
        {
            animator.SetTrigger(HideKey);
        }
    }
}