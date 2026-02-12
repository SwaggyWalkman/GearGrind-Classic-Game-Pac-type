using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Rivals [] Rivals; // Equivalent to the ghosts array in the video
    // in the video, GameObject[] Rivals(ghost in the video) was instead put as Ghosts[] ghosts;
    // I kept it as GameObject[] because doing it like the video cause an error I did not understand how to fix
    // at the moment, everything else seems to be working fine.

    public Player Player;
    public GameObject winScreen_UI;
    public GameObject loseScreen_UI;

    [SerializeField] private Transform powers; // pellet equivalent

    public int rivalMultiplier {get; private set;} = 1;

    public int score {get; private set;}
    public int lives {get; private set;}
    private bool isGameOver = false;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewGame();
        winScreen_UI.SetActive(false);
        loseScreen_UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if case if any key is pressed to start a new game after game over
        //left it as just space for now
        if (this.lives <= 0 && Input.GetKeyDown(KeyCode.Space))    
        {
            NewRound();
        }
    }

    
    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
    }

    private void NewRound()
    {
        foreach (Transform power in powers)
        {
            power.gameObject.SetActive(true);
        }

        ResetState();
        
    }

    private void GameOver()
    {
            for (int i = 0; i < this.Rivals.Length; i++)
            {
                this.Rivals[i].gameObject.SetActive(false);
            }

            this.Player.gameObject.SetActive(false);

            isGameOver = true;

            loseScreen_UI.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
    }

    private void ResetState()
    {
        resetRivalMultiplier();
        
        for (int i = 0; i < this.Rivals.Length; i++)
        {
            this.Rivals[i].ResetState();
        }

        this.Player.ResetState();
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void RivalEaten(Rivals Rivals)
    {
        int points = Rivals.points * rivalMultiplier;
        SetScore(this.score + points); // Assuming each rival is worth 200 points
        Rivals.SetPosition(Rivals.home.homeTransform.position);

        // Disable all behaviors except home
        Rivals.scatter.Disable();
        Rivals.chase.Disable();
        Rivals.vulnerable.Disable();

        // Enable home behavior (this triggers ExitTransition)
        Rivals.home.Enable(3.0f);
    }

    public void PlayerEaten()
    {
        this.Player.gameObject.SetActive(false);
        SetLives(this.lives - 1);

        if (this.lives > 0)// checks lives
        {
            
            Invoke(nameof(ResetState), 3.0f); // doesn't reset everything, just the rivals and player, also resets after a couple of seconds
        }
        else
        {
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.points);
        if (!PelletsLeft())
        {
            WinScreen();
        }
    }

    public void PowerPelletEaten(PowerPellet powerPellet)
    {
        // TODO: changing ghost state
        for (int i = 0; i < this.Rivals.Length; i++)
        {
            this.Rivals[i].vulnerable.Enable(powerPellet.duration);
        }

        // resets rival multiplier after 10 seconds
        PelletEaten(powerPellet); // calls pellet eaten to add points and hide the power pellet
        CancelInvoke();
        Invoke(nameof(resetRivalMultiplier), powerPellet.duration); //video calls pellet, not power pellet, going to test it first

    }

    private bool PelletsLeft()
    {
        foreach (Transform power in this.powers)
        {
            if (power.gameObject.activeSelf)
            {
                return true;
            }
        }

        return false;
    }
    
    private void resetRivalMultiplier()
    {
        rivalMultiplier = 1;
    }

    public void LoseScreen()
    {
        if (isGameOver)
        {
            loseScreen_UI.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
    }

    public void WinScreen()
    {
        if (!PelletsLeft())
        {
            for (int i = 0; i < this.Rivals.Length; i++)
            {
                this.Rivals[i].gameObject.SetActive(false);
            }

            this.Player.gameObject.SetActive(false);

            winScreen_UI.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
    }

    public void PlayAgainButton()
    {
        Time.timeScale = 1f;
        loseScreen_UI.SetActive(false);
        winScreen_UI.SetActive(false);
        NewRound();
        AudioListener.pause = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu_UI");
        AudioListener.pause = false;
    }

}
