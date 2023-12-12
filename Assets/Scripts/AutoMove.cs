using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform[] checkpoints;
    private int currentCheckpointIndex = 0;
    public float speed = 5f;

    void Update()
    {
      
        Vector3 targetPosition = checkpoints[currentCheckpointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
       

     

        // Check if the character has reached the current checkpoint
        if (transform.position == targetPosition)
        {
            currentCheckpointIndex++;

            // If the character reached the last checkpoint, loop back to the first one
            if (currentCheckpointIndex >= checkpoints.Length)
            {
                currentCheckpointIndex = 0;
            }
        }
    }
}
