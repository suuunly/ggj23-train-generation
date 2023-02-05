using System.Collections;
using System.Collections.Generic;
using Player;
using Rooms;
using UnityEngine;

namespace Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private RoomPool poolOfRooms;
        [SerializeField] private List<float> speeds;
        [SerializeField] private float increasePointsBySeconds;
        [SerializeField] private PointsManager points;

        private int _currentSpeedIndex;

        private LevelSegment _edgeSegment;
        private LevelSegment[] _segments = { };

        private void Awake()
        {
            _segments = GetComponentsInChildren<LevelSegment>();
            _edgeSegment = _segments[^1];
        }

        private void Start()
        {
            foreach (LevelSegment segment in _segments)
            {
                segment.OnLevelSegmentReset += ResetSegment;
                segment.SetSpeed(speeds[_currentSpeedIndex]);
            }

            StartCoroutine(PointsRoutine());
        }

        private void OnDestroy()
        {
            foreach (LevelSegment segment in _segments)
            {
                segment.OnLevelSegmentReset -= ResetSegment;
            }

            StopAllCoroutines();
        }

        private IEnumerator PointsRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(increasePointsBySeconds);
                points.IncreaseScore();
            }
        }

        private void ResetSegment(LevelSegment segment)
        {
            // right hand side of edge segment (furthest to the right)
            Vector3 rhsOfEdge = _edgeSegment.transform.position + Vector3.right * _edgeSegment.Width * 0.5f;
            Vector3 newSegmentPos = rhsOfEdge + Vector3.right * segment.Width * 0.5f;

            segment.transform.position = newSegmentPos;
            segment.ApplyNewRoom(poolOfRooms.GetRoom());

            _edgeSegment = segment;
        }

        public void SlowDown()
        {
            _currentSpeedIndex = Mathf.Min(_currentSpeedIndex + 1, speeds.Count);
            foreach (LevelSegment segment in _segments)
            {
                segment.SetSpeed(speeds[_currentSpeedIndex]);
            }
        }
    }
}