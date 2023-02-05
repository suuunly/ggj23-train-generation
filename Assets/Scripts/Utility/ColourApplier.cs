using UnityEngine;

namespace Utility
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ColourApplier : MonoBehaviour
    {
        [SerializeField] private Color[] colors;

        private void Awake()
        {
            var render = GetComponent<SpriteRenderer>();
            render.color = colors[Random.Range(0, colors.Length)];
        }
    }
}