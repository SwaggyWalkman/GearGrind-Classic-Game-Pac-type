using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject [] Rivals; // Equivalent to the ghosts array in the video
    // in the video, GameObject[] Rivals(ghost in the video) was instead put as Ghosts[] ghosts;
    // I kept it as GameObject[] because doing it like the video cause an error I did not understand how to fix
    // at the moment, everything else seems to be working fine.

    public GameObject Player;
    public Transform powers;

    public int score {get; private set;}
    public int lives {get; private set;}
     
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        //if case if any key is pressed to start a new game after game over
        //left it as just space for now
        if (this.lives <= 0 && Input.GetKeyDown(KeyCode.Space))    
        {
            NewGame();
        }
    }

    
    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
    }

    private void NewRound()
    {
        foreach (Transform power in this.powers)
        {
            power.gameObject.SetActive(true);
        }

        ResetState();
        
    }

    private void GameOver()
    {
        for (int i = 0; i < this.Rivals.Length; i++)
        {
            this.Rivals[i].gameObject.SetActive(true);
        }

        this.Player.gameObject.SetActive(false);
    }

    private void ResetState()
    {
        for (int i = 0; i < this.Rivals.Length; i++)
        {
            this.Rivals[i].gameObject.SetActive(true);
        }

        this.Player.gameObject.SetActive(true);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void RivalEaten(GameObject rivals)
    {
        SetScore(this.score + 200); // Assuming each rival is worth 200 points
        rivals.SetActive(false);
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
}
