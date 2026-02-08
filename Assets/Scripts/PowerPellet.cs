using UnityEngine;

public class PowerPellet : Pellet
{

    public float duration = 10.0f; // Duration of the power-up effect in seconds
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    protected override void Eat()
    {
        FindObjectOfType<GameManager>().PowerPelletEaten(this);
    }
}
