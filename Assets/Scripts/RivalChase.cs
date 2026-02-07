using UnityEngine;

public class RivalChase : RivalBehavior
{
    private void OnDisable()
    {
        this.rivals.scatter.Enable();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Node node = other.GetComponent<Node>();
        
        if (node != null && this.enabled && !this.rivals.vulnerable.enabled)
        {
            Vector2 direction = Vector2.zero;
            float shortestDistance = float.MaxValue;

            foreach(Vector2 availableDirection in node.availableDirections)
            {
                if (availableDirection == -rivals.movement.direction && node.availableDirections.Count > 1)
                {
                continue;
                }
                
                Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);
                float distance = (rivals.target.position - newPosition).sqrMagnitude;

                if (distance < shortestDistance)
                {
                    direction = availableDirection;
                    shortestDistance = distance;
                }
            }

            rivals.movement.setDirection(direction);
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
