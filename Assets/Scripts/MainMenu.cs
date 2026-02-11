using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu_UI;

    void Start()
    {
        mainMenu_UI.SetActive(true);
    }

    private void Update()
    {
    }

    public void LevelOneButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("DungeonKnights!");
    }

    public void LevelTwoButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("DungeonKnights! Level 2");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

