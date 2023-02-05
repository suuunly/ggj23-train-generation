public static class GameState
{
    public static bool GameIsOver { get; private set; }

    public static void GameOver()
    {
        GameIsOver = true;
    }

    public static void Reset()
    {
        GameIsOver = false;
    }
}