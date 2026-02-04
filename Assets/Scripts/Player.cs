using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour
{
    public Movement movement { get; private set; }

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }

    private void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            direction = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            direction = Vector2.right;
        }

        if (direction != Vector2.zero)
        {
            this.movement.SetDirection(direction);
        } 
    }
    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();
    }
}

