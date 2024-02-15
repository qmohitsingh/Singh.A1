using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Horizontal movement speed
    public float moveRange = 8f; // Range of horizontal movement from the starting point
    public float forwardMoveStep = 4f; // The step size to move forward on each direction change

    private Vector3 startPosition;
    private bool movingRight = true; // Track the direction of horizontal movement

    void Start()
    {
        startPosition = transform.position; // Remember start position for movement range calculation
    }

    void Update()
    {
        // Calculate the current position relative to the start position
        float currentPosRelativeToStart = movingRight ? transform.position.x - startPosition.x : startPosition.x - transform.position.x;

        // Determine if the enemy should change direction
        if (currentPosRelativeToStart >= moveRange)
        {
            movingRight = !movingRight; // Change direction
            MoveForward(); // Move forward each time the direction changes
        }

        // Move the enemy in the current horizontal direction
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        
    }

    // Moves the enemy forward by a fixed step
    void MoveForward()
    {
        transform.position += Vector3.back * forwardMoveStep; // Adjust Vector3.forward to your game's forward direction
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "PlayerBullet") {
            Destroy(gameObject);
            Destroy(other.gameObject); // Destroy the bullet
        }
        
    }
}
