using UnityEngine;

namespace Rooms
{
    public abstract class RoomSpawnObserver : MonoBehaviour
    {
        public abstract void OnSpawned();
    }
}