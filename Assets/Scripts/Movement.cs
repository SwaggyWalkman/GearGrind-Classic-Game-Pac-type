using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{   
    public Rigidbody2D Rigidbody { get; private set; }
    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    public Vector2 initialDirection; //direction varies from object to object
    public LayerMask WallsLayer;// gonna use raycasts for checking walls

    public Vector2 direction { get; private set;} 
    public Vector2 nextDirection { get; private set;} //you can queue up movements in the arcade game, so let's replicate that here

    public Vector3 startingPosition { get; private set;}
     
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetState();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextDirection != Vector2.zero) // keeps player going in same direction if no button is pressed
        {
            setDirection(nextDirection);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = this.Rigidbody.position;
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime;
        this.Rigidbody.MovePosition(position + translation);
    }

    public void setDirection (Vector2 direction, bool forced = false)
    {
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else
        {
            this.nextDirection = direction;
        }
        
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.WallsLayer);
        return hit.collider != null;
    }

    private void Awake ()
    {
        this.Rigidbody = GetComponent<Rigidbody2D>();
        this.startingPosition = this.transform.position;
    }

    public void resetState()
    {
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.Rigidbody.isKinematic = false; // will be used for ghosts, makes them able to pass through the first wall
        this.enabled = true;
    }
}
