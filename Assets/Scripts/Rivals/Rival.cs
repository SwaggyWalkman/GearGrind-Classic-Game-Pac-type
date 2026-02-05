using UnityEngine;

public class Rival : MonoBehaviour
{
 

    public Movement movement { get; private set; }

    public RivalHome home { get; private set; }

    public RivalScatter scatter { get; private set; }

    public RivalChase chase { get; private set; }

    public RivalFrightened frightened { get; private set; }
   
    public RivalBehavior initialBehavior;

    public Transform target;

    public int points = 200;
    

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<RivalHome>();
        this.scatter = GetComponent<RivalScatter>();
        this.chase = GetComponent<RivalChase>();
        this.frightened = GetComponent<RivalFrightened>();
    }
    /// I believe this area is the toggles between the scripts, it retrieves from all Rival behaviors. It's where they may switch between modes.
    /// 
    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enabled();
        
        if(this.home != this.initialBehavior)
        {             this.home.Disable();
        }

        if(this.initialBehavior != null)
        {
            this.initialBehavior.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (this.frightened.enabled)
            {
               FindObjectOfType<GameManager>().RivalEaten(this);
            } else
            {
                FindObjectOfType<GameManager>().PlayerEaten();
            }
        }
    }
}
