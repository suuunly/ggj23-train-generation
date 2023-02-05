using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PointsManager : MonoBehaviour
    {
        [SerializeField] private UnityEvent<int> scoreIncreased;

        [SerializeField] private int pointIncreaseAmount;

        public int CurrentPoints { get; private set; }

        public void IncreaseScore()
        {
            CurrentPoints += pointIncreaseAmount;
            scoreIncreased.Invoke(CurrentPoints);
        }
    }
}