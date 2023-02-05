using UnityEngine;

namespace Rooms.Observers
{
    public class ChangeColourOnSpawn : RoomSpawnObserver
    {
        [SerializeField] private SpriteRenderer render;

        public override void OnSpawned()
        {
            float r = Random.Range(0, 1.0f);
            float g = Random.Range(0, 1.0f);
            float b = Random.Range(0, 1.0f);

            render.color = new Color(r, g, b);
        }
    }
}