using UnityEngine;using System.Collections.Generic;

public class Node : MonoBehavior
{
    public LayerMask obstacleLayer;

    public List<Vector2> availableDIrections { get; private set; }


    private void Start()
    {
        this.availableDIrections = new List<Vector2>();

        CheckAvailableDirections(Vector2.up);
        CheckAvailableDirections(Vector2.down);
        CheckAvailableDirections(Vector2.left);
        CheckAvailableDirections(Vector2.right);
    }

    private void CheckAvailableDirections(Vector 2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.one * .5f, 0.0f, direction, 1.5f, this.obstacleLayer);

        if (hit.collider == null)
        {
            this.availableDIrections.Add(direction);
        }
    }
}

//This script has to be a component for the Node game object in Unity. It checks for available movement directions by casting rays in four cardinal directions and stores the valid directions in a list.