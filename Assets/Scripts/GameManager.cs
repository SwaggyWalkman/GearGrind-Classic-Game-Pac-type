using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scene References")]
    public GameObject Player;     // The player character
    public Transform Pellets;     // Parent object containing all pellet children

    [Header("Game Stats")]
    public int Lives { get; private set; }
    public int Score { get; private set; }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        // Restart when out of lives
        if (Lives <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            NewGame();
        }
    }

    // ------------------------------
    // GAME FLOW
    // ------------------------------

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        if (Pellets == null)
        {
            Debug.LogError("❌ Pellets Transform not assigned in GameManager!");
            return;
        }

        // Reactivate all pellets (make them visible again)
        foreach (Transform pellet in Pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }
    //All my changes for the hour 2 mark happened here, where I changes some components of the Reset State.
    private void GameOver()
    {
        Player.gameObject.SetActive(false);
    }

    private void ResetState()
    {
        ResetRivalMultiplier();

        for (int i = 0; i <this.rival.Length; i++)
        {
            this.rivals[i].ResetState();
        }

        this.Player.ResetState();
    }

    // ------------------------------
    // SCORING & LIVES
    // ------------------------------

    private void SetScore(int value)
    {
        Score = value;
        Debug.Log("Score: " + Score);
    }

    private void SetLives(int value)
    {
        Lives = value;
        Debug.Log("Lives: " + Lives);
    }

    // ------------------------------
    // EVENTS
    // ------------------------------

    //I added a Rival Eaten method here, although I'm not sure if it's fully correct.
    public void RivalEaten(Rival rival)
    {
        int pointsEarned = rival.points * this.rivalMultiplier;
        SetScore(Score + pointsEarned);
        this.rivalMultiplier++;
    }

    public void PlayerEaten()
    {
        Player.SetActive(false);
        SetLives(Lives - 1);

        if (Lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
        }
        else
        {
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        SetScore(Score + pellet.points);

        int remaining = CountActivePellets();

        Debug.Log("🍬 Pellet eaten! Pellets left: " + remaining);

        if (remaining == 0)
        {
            Debug.Log("✅ All pellets eaten! Starting new round...");
            Player.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        PelletEaten(pellet);  // Gains normal pellet points too
        Debug.Log("💥 Power Pellet eaten!");
        // Add power-up effects here (if you add ghosts later)
    }

    // ------------------------------
    // HELPER METHODS
    // ------------------------------

    private int CountActivePellets()
    {
        if (Pellets == null)
        {
            Debug.LogError("❌ Pellets Transform not assigned in GameManager!");
            return 0;
        }

        int count = 0;

        // Search all child transforms (including nested)
        foreach (Transform child in Pellets.GetComponentsInChildren<Transform>(includeInactive: false))
        {
            if (child != Pellets && child.gameObject.activeSelf)
            {
                count++;
            }
        }

        return count;
    }
}
