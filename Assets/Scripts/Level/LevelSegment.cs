using System;
using Rooms;
using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class LevelSegment : MonoBehaviour
    {
        [SerializeField] private Room currentRoom;

        private Rigidbody2D _body;
        private float _speed;

        public float Width { get; private set; }

        private void Awake()
        {
            Width = GetComponent<Collider2D>().bounds.size.x;

            _body = GetComponent<Rigidbody2D>();
            _body.isKinematic = true;
        }

        private void FixedUpdate()
        {
            _body.velocity = Vector2.left * _speed;
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            Vector3 pos = transform.position;

            Vector3 leftSide = pos;
            Vector3 rightSide = pos;

            leftSide.x -= Width * 0.5f;
            rightSide.x += Width * 0.5f;

            Gizmos.DrawLine(leftSide, rightSide);
        }

        public event Action<LevelSegment> OnLevelSegmentReset;

        public void SetSpeed(float speed)
        {
            _speed = speed;
            if (currentRoom != null)
            {
                currentRoom.SetSpeed(speed);
            }
        }

        public void ResetSegment()
        {
            OnLevelSegmentReset?.Invoke(this);
        }

        public void ApplyNewRoom(Room room)
        {
            if (currentRoom != null)
            {
                Destroy(currentRoom.gameObject);
                currentRoom = null;
            }

            Transform trans = room.transform;
            trans.SetParent(transform);
            trans.localPosition = Vector3.zero;

            room.SetSpeed(_speed);

            currentRoom = room;
        }
    }
}