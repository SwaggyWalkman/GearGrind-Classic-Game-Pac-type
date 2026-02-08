using UnityEngine;

public class RivalVulnerable : RivalBehavior
{
    
    public SpriteRenderer Body_standard;
    public SpriteRenderer Body_vulnerable;
    public SpriteRenderer Body_Almost_Done;

    public bool eaten { get; private set; }

    public override void Enable(float duration)
    {
        base.Enable(duration);

        this.Body_standard.enabled = false;
        this.Body_vulnerable.enabled = true;
        this.Body_Almost_Done.enabled = false;


        Invoke(nameof(Flash), duration / 2.0f);   
    }

    public override void Disable()
    {
        base.Disable();

        this.Body_standard.enabled = true;
        this.Body_vulnerable.enabled = false;
        this.Body_Almost_Done.enabled = false;

        this.eaten = false;
    }

    private void Flash()
    {
        if (!this.eaten)
        {
            this.Body_vulnerable.enabled = false;
            this.Body_Almost_Done.enabled = true;
        }
    }

    private void OnEnable()
    {
        this.rivals.movement.speedMultiplier = 0.5f;
        this.eaten = false;
    }
    
    private void OnDisable()
    {
        this.rivals.movement.speedMultiplier = 1.0f;
        this.eaten = false;
    }

    private void Eaten()
    {
        this.eaten = true;
        
        this.rivals.SetPosition(this.rivals.home.transform.position);
        this.rivals.home.Enable(this.duration);

        this.Body_standard.enabled = false;
        this.Body_vulnerable.enabled = false;
        this.Body_Almost_Done.enabled = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Knightro"))
        {
            if (this.enabled)
            {
                Eaten();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Node node = other.GetComponent<Node>();
        
        if (node != null && this.enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach(Vector2 availableDirection in node.availableDirections)
            {
                                
                if (availableDirection == -rivals.movement.direction && node.availableDirections.Count > 1)
                {
                    continue;
                }
                
                Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);
                float distance = (rivals.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }

            rivals.movement.setDirection(direction);
        }
    }
    
    
}
