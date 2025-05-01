using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine.XR;

public class Chicken : MonoBehaviour
{
    public float speed;
    //private bool isRunning; 
    private int facingDirection = -1;
    private ChickenState chickenstate; // Make it private, this means we don't see it in Unity
    private Animator anim;

    // Create a public rigidbody reference
    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Search game object for animator and fill that slot
        ChangeState(ChickenState.Idle);

    }

    void Update()
    {
        if(chickenstate == ChickenState.Walking)
        {
            // Check if player is on the right side of our animal, or if it is on the left, direction of -1 means facing left and 1 is right
            if(player.position.x > transform.position.x && facingDirection == 1 || player.position.x < transform.position.x && facingDirection == -1)
            {
                Flip();
            }
            // create a vector pointing from the player to the chicken, this allows it to run away
            Vector2 direction = (transform.position - player.position).normalized; 
            rb.linearVelocity = direction * speed;
        }
    }

    void Flip()
    {
        facingDirection *= -1; // make it the opposite direction, flip the variable
        // Flip the actual object
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "Player")
        {   if(player == null)
            {
                player = collision.transform; // tell the animal that the player is equal to the object that just entered the collider
            }
            ChangeState(ChickenState.Walking);
        }
    }   

    
     void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero; // do this so that when we leave the enemy's trigger area, the enemy doesn't keep moving in the same direction
            ChangeState(ChickenState.Idle);
        }
    }

    void ChangeState(ChickenState newState)
    {

         // Leave our current animation
        if(chickenstate == ChickenState.Idle)
        {
            anim.SetBool("isIdle" ,false);
        }
        else if(chickenstate == ChickenState.Walking)
        {
            anim.SetBool("isWalking", false);
        }
        
        // update current state
        chickenstate = newState;

        // update new animation
        if(chickenstate == ChickenState.Idle)
        {
            anim.SetBool("isIdle" , true);
        }
        else if(chickenstate == ChickenState.Walking)
        {
            anim.SetBool("isWalking", true);
        }
    }
}

// This is like creating our own variable
public enum ChickenState
{
    Idle,
    Walking,
}