using UnityEngine;

public class Rivals : MonoBehaviour
{
    public Movement movement { get; private set; }
    public RivalHome home { get; private set; }
    public RivalScatter scatter { get; private set; }
    public RivalChase chase { get; private set; }
    public RivalVulnerable vulnerable { get; private set; }
    public RivalBehavior initialBehavior;
    public Transform target;
    


    public int points = 200;
    
    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<RivalHome>();
        this.scatter = GetComponent<RivalScatter>();
        this.chase = GetComponent<RivalChase>();
        this.vulnerable = GetComponent<RivalVulnerable>();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();
        
        this.vulnerable.Disable(); //Rivals never start in any of these states
        this.chase.Disable();
        this.scatter.Enable();
        
        if (this.home != this.initialBehavior)
        {
            this.home.Disable();
        }
        if (this.initialBehavior != null)
        {
            this.initialBehavior.Enable();
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(Vector3 position)
    {
        position.z = transform.position.z;
        transform.position = position;

        movement.ResetState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Knightro"))
        {
            if (this.vulnerable.enabled)
            {
                FindObjectOfType<GameManager>().RivalEaten(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PlayerEaten();
            }
        }
    }
}
