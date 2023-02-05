using UnityEngine;

namespace Rooms
{
    public class RoomSpeedEffector : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D body;

        private float _speed;

        private void FixedUpdate()
        {
            Vector2 velocity = body.velocity;
            velocity.x = -_speed;

            body.velocity = velocity;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
    }
}