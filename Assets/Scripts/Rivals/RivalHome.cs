using System.Collections;
using UnityEngine;

public class RivalHome : RivalBehavior
{
    public Transform inside;

    public Transform outside;


    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(ExitTransition());
        }
    }

    //Should be the rival bouncing off the walls of their home
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (this.enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            this.rival.movement.setDirection(-this.rival.movement.direction);
        }
    }

    private IEnumerator ExitTransition()
    {
        this.rival.movement.setDirection(Vector2.up, true)l
        this.rival.movement.rigidbody.isKinematic = true;
        this.rival.movement.enabled= false;


        Vector3 position = this.transform.position;
        float duration = 0.5f;
        float elapsed = 0.0f;

        //The while chunk should be an animation of them exiting?
        while(elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(position, this.inside.position, elapsed / duration);
            newPosition.z = position.z;
            this.rival.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(position, this.outside.position, elapsed / duration);
            newPosition.z = position.z;
            this.rival.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        this.rival.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1 : 1, 0), true);)
        this.rival.movement.rigidbody.isKinematic = false;
        this.rival.movement.enabled = true;
    }
}


//THIS IS IMPORTANT this another important thing that I'm unable to do since the scripts are failing on me is implementing the inside and outside
//nodes into the RivalHome script for each of the rivals. This is something that was required to be done at timestamp 2:55:00