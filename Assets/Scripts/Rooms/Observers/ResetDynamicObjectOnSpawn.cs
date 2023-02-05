using UnityEngine;

namespace Rooms.Observers
{
    public class ResetDynamicObjectOnSpawn : RoomSpawnObserver
    {
        private Vector2 _originalPosition;
        private Quaternion _originalRotation;

        private void Awake()
        {
            Transform trans = transform;

            _originalPosition = trans.localPosition;
            _originalRotation = trans.rotation;
        }

        public override void OnSpawned()
        {
            Transform trans = transform;

            trans.position = _originalPosition;
            trans.rotation = _originalRotation;
        }
    }
}