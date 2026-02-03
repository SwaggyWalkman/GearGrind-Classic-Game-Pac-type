using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int points = 10;

    protected virtual void Eat()
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.PelletEaten(this);
        }
        else
        {
            Debug.LogWarning("GameManager not found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only react if the player touches it
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Pellet collided with player!"); // <-- should appear when hit
            Eat();
        }
    }
}
