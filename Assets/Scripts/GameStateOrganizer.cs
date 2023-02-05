using UnityEngine;

public class GameStateOrganizer : MonoBehaviour
{
    private void Awake()
    {
        GameState.Reset();
    }
}