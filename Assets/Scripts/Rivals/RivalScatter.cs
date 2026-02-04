using UnityEngine;

public class RivalScatter : RivalBehavior
{
    private void OnDisable()
    {
        this.rival.chase.Enable();
    }

    private voice OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && !this.enabled && !this.rival.frightened.enabled)
        {
            int index = Random.Range(0, node.availableDIrections.Count);

            if (node.availableDirections[index] == -this.rival.movement.direction && node.availableDirections.Count >1)
            {
                index++;

                if (index >= node.availableDIrections.Count)
                {
                    index = 0;
                }
                this.rival.movement.SetDirections(node.availableDirections[index]);
            }
        }
    }
}

//This should allow the rival to randomly choose a new direction when it reaches a node, as long as it is not reversing direction and is not frightened.
//