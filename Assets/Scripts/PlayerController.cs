using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed = 7f; // Speed in float type.
    public float speed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody; // Declaration of main physics engine.
    public Transform groundCheckPoint; // Allows us to go back to the checkpoint we created.
    public float groundCheckRadius; // Checks how close the player model is to the ground.
    public LayerMask groundLayer; 
    private bool isTouchingGround; // Checks if the player's hitbox is currently touching the ground.
    private Animator playerAnimation;
    public Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()  
    {
        rigidBody = GetComponent<Rigidbody2D>(); // We create the Rigidbody which is the main physics component to our player which allows us to be affected by gravity.
        playerAnimation = GetComponent<Animator>(); // Allows us to access the animation module which causes the player to do his running animation.
        respawnPoint = transform.position; // Transforms the player's current point to the nearest respawn point.
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer); // Checks if player is touching ground.
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f) // Calculates speed when moving and allows us to accelerate/ decelerate.
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(0.5837948f, 0.5837948f);
        }
        else if (movement < 0f) // When we are idle.
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-0.5837948f, 0.5837948f);
        }
        else 
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y); 
        }
        if (Input.GetButtonDown("Jump") && isTouchingGround == true) // Allows the player model to jump ONLY when he is touching the ground.
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        playerAnimation.SetFloat("Speed", Mathf.Abs (rigidBody.velocity.x));
        playerAnimation.SetBool("On Ground", isTouchingGround); 
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "FallDetector") // This makes the player respawn when he falls off the map in the game.
        {
            transform.position = respawnPoint;
        }
        if(other.tag == "Checkpoint") // This causes the player to respawn to the nearest checkpoint when he dies.
        {
            respawnPoint = other.transform.position;
        }
    }


}
