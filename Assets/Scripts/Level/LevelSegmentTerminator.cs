using UnityEngine;

namespace Level
{
    public class LevelSegmentTerminator : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.TryGetComponent(out LevelSegment segment))
            {
                return;
            }

            segment.ResetSegment();
        }
    }
}