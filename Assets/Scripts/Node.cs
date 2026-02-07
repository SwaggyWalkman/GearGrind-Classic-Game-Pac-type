using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    public List<Vector2> availableDirections { get; private set; } // List of available directions at this node
    public LayerMask WallsLayer; // Layer mask for walls to check for available directions

    private void Start()
    {
        availableDirections = new List<Vector2>();
        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down); 
        CheckAvailableDirection(Vector2.left);
        CheckAvailableDirection(Vector2.right);

    }

    private void CheckAvailableDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, this.WallsLayer);
        if (hit.collider == null)
        {
            this.availableDirections.Add(direction);
        }
        
    }
}
