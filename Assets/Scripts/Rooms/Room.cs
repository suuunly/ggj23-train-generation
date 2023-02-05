using UnityEngine;

namespace Rooms
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private RoomSpeedEffector[] speedEffectors;

        private void Reset()
        {
            speedEffectors = GetComponentsInChildren<RoomSpeedEffector>()
                             ?? new RoomSpeedEffector[] { };
        }

        public void SetSpeed(float speed)
        {
            foreach (RoomSpeedEffector effector in speedEffectors)
            {
                effector.SetSpeed(speed);
            }
        }
    }
}