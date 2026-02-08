using UnityEngine;



public class RivalScatter : RivalBehavior
{
    private void OnDisable()
    {
        this.rivals.chase.Enable();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Node node = other.GetComponent<Node>();
        
        if (node != null && this.enabled && !this.rivals.vulnerable.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections[index] == -this.rivals.movement.direction && node.availableDirections.Count > 1)
            {
                index++;

                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            this.rivals.movement.setDirection(node.availableDirections[index]);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
