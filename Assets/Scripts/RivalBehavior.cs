using UnityEngine;

[RequireComponent(typeof(Rivals))] // ensures that any GameObject with a RivalBehavior also has a Rivals component, which is necessary for accessing the rival's state and properties

public abstract class RivalBehavior : MonoBehaviour
{
    public Rivals rivals { get; private set; } // reference to the parent Rivals script, which will be used to access the rival's state and other properties
    public float duration; // duration for which the behavior is active, can be set in the inspector or through code

    private void OnEnable()
    {
        rivals = GetComponent<Rivals>(); // get the Rivals component from the same GameObject
        
    }

    public void Enable()
    {
        Enable(duration);
    }

    public virtual void Enable (float duration)
    {
        this.enabled = true;

        CancelInvoke(); 
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        this.enabled = false;

        CancelInvoke();
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
