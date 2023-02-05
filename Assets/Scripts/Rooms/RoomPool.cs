using UnityEngine;

namespace Rooms
{
    public class RoomPool : MonoBehaviour
    {
        [SerializeField] private Room[] roomPrefabs;

        public Room GetRoom()
        {
            int i = Random.Range(0, roomPrefabs.Length);
            Room room = Instantiate(roomPrefabs[i]);

            return room;
        }
    }
}