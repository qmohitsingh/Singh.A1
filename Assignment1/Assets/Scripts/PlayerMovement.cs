using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private bool isTouchingLeftWall = false;
    private bool isTouchingRightWall = false;
    
    void Start()
    {
        speed = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        //Debug.Log("horizontalMovement: "+ horizontalMovement);

        //Vector3 movement = new Vector3(horizontalMovement, 0, 0);
        //Debug.Log("movement: "+ movement);
        
        //transform.Translate(movement * speed * Time.deltaTime);

        // Allow movement if not touching any wall or moving away from the wall
        if ((!isTouchingLeftWall || horizontalMovement > 0) && (!isTouchingRightWall || horizontalMovement < 0))
        {
            Vector3 movement = new Vector3(horizontalMovement, 0, 0);
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }

    // private void OnTriggerEnter(Collider other) {
    //     if (other.CompareTag("Walls")) {
    //         Debug.Log("walls with player");
    //     }
    // }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Walls"))
        {
            // Determine if the wall is on the left or right
            if (transform.position.x > other.transform.position.x)
            {
                // Wall is to the left
                isTouchingLeftWall = true;
            }
            else
            {
                // Wall is to the right
                isTouchingRightWall = true;
            }
        }

        if (other.gameObject.tag == "Enemy") {
            // Assuming this script is attached to the player
            //GameManager.instance.EndGame();
            Destroy(gameObject);
            Destroy(other.gameObject); // Destroy the enemy
        }

        if (other.gameObject.tag == "EnemyBullet") {
            // Assuming this script is attached to the player
            //GameManager.instance.EndGame();
            GameManager.instance.OnPlayerDeath();
            Destroy(gameObject);
            Destroy(other.gameObject); // Destroy the bullet
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Walls"))
        {
            // Reset both flags, since we don't know which wall we exited
            isTouchingLeftWall = false;
            isTouchingRightWall = false;
        }
    }
}
