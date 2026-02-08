using System.Collections;
using UnityEngine;

public class RivalHome : RivalBehavior
{
    public Transform homeTransform;
    public Transform outside;
    

    
    
    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        if (gameObject.activeInHierarchy) {
            StartCoroutine(ExitTransition());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled && collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            rivals.movement.setDirection(-rivals.movement.direction);
        }
    }
    
    private IEnumerator ExitTransition()
    {
        Rigidbody2D rb = rivals.movement.GetComponent<Rigidbody2D>();
        
        this.rivals.movement.setDirection(Vector2.up, true);
        rb.isKinematic = true;
        this.rivals.movement.enabled = false;

        Vector3 position = this.transform.position;

        float duration = 0.5f;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(position, this.homeTransform.position, elapsed / duration);
            newPosition.z = position.z;
            this.rivals.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(this.homeTransform.position, this.outside.position, elapsed / duration);
            newPosition.z = position.z;
            this.rivals.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }


        this.rivals.movement.setDirection(new Vector2(Random.value < 0.5f ? -1.0f : 1.0f, 0.0f), true);
        rb.isKinematic = false;
        this.rivals.movement.enabled = true;
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
