using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{   
    public Rigidbody2D Rigidbody { get; private set; }
    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    public LayerMask WallsLayer;// gonna use raycasts for checking walls

    public Vector2 direction { get; private set;}

    public Vector2 nextDirection { get; private set;}
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake ()
    {
        this.Rigidbody = GetComponent<Rigidbody2D>();
    }
}
