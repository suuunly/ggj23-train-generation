using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void OnExit()
    {
        Application.Quit();
        Debug.Log("EXIT");
    }
}