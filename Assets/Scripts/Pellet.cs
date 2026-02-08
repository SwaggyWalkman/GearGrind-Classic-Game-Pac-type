using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int points = 10;

    
    protected virtual void Eat() // now method can be used by Power Pellets too
    {
        FindObjectOfType<GameManager>().PelletEaten(this);
        
        this.gameObject.SetActive(false); // Hide the pellet instead of destroying it

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Knightro"))
        {
            Eat();
        }
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
