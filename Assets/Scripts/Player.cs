using UnityEngine;


public class Player : MonoBehaviour
{
    public Movement movement { get; private set;} 
    
    

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }
   
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                movement.setDirection(Vector2.up);
            }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                movement.setDirection(Vector2.down);
            }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                movement.setDirection(Vector2.left);
            }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                movement.setDirection(Vector2.right);
            }

        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x); // causes player to rotate
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void ResetState()
    {
        this.movement.ResetState();
        this.gameObject.SetActive(true);
        
    }
}
