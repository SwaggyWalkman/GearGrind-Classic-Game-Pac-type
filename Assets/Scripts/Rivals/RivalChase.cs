using UnityEngine;

public class RivalChase : RivalBehavior
{
    private void OnDisable()
    {
        this.rival.scatter.Enable();
    }

    private voice OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && !this.enabled && !this.rival.frightened.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            foreach (var  (Vector2 availableDirection in node.availableDirections) in collection)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);

                float distance = (this.rival.target.position - newPosition).sqrMagnitude;

                if (distance < minDistance)
                {
                    direction = availableDirection;
                    minDistance = distance;
                }
            }
            this.rival.movement.SetDirections(direction);
        }
    }
}

//Chase should make the rival hunt the closest node to the player to kill them.