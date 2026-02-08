using UnityEngine;


public class Passage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    public Transform connection;
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        Vector3 Position = other.transform.position;
        Position.x = this.connection.position.x;
        Position.y = this.connection.position.y;

        other.transform.position = Position;
        
    }
    
    
}
