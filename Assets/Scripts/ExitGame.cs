using UnityEngine;

public class ExitGame : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }


    void QuitGame()
    {
        Debug.Log("Quitting game...");

        Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false;
    }
}
