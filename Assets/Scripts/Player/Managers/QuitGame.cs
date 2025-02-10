using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)) CloseGame();
    }

    private void CloseGame()
    {
        Application.Quit();
    }
}
