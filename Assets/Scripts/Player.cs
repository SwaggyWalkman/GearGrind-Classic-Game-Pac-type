using UnityEngine;
using UnityEngine.InputSystem;

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
        if (Input.GetKeyDown(KeyCode.W) || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            this.movement.setDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            this.movement.setDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            this.movement.setDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            this.movement.setDirection(Vector2.right);
        }

        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x); // causes player to rotate
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }
}
