using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // The force applied to the player to make them jump
    public float jumpThrustForce = 8.0f; 
    private Rigidbody2D playerRigidbody2D;
    private bool isPlayerOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space key is pressed and if the player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerOnGround)
        {
            // Make the player jump by adding force to the y-axis
            // ForceMode2D.Impulse adds an instant force to the Rigidbody2D
            playerRigidbody2D.AddForce(Vector2.up * jumpThrustForce, ForceMode2D.Impulse);

            // The player is no longer on the ground after jumping
            isPlayerOnGround = false;
        }
    }

    // Check if the player has collided with the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with an object tagged as "Ground", set isPlayerOnGround to true
        if (collision.gameObject.CompareTag("Ground"))
        {
            isPlayerOnGround = true;
        }
    }
}
