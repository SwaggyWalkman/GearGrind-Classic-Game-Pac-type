using UnityEngine;

[RequireComponent(typeof(Rival))]

public abstract class RivalBehavior : MonoBehaviour
{
    public Rival rival { get; private set; }

    public float duration;

    private void Awake()
    {
        this.rival = GetComponent<Rival>();
        this.enabled = false;
    }


    public void Enable()
    {
        Enable(this.duration());
    }

    public virtual void Enable(float duration)
    {
        this.enabled = true;

        CancelInvoke();
        invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        this.enabled = false;

        CancelInvoke();
    }

}