using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 15f;
    public float jumpTimeLimit = 0.35f;
    public float fallMultiplier = 5;
    public float lowJumpMultipler = 4;

    private float jumpTimer;
    private Rigidbody rb;
    private float zPosition;
    private PlayerInput playerInput;
    private bool canJump;
    public bool isGrounded { get; set; }



    private void Awake()
    {
        //Initialize fields
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        zPosition = rb.position.y;
        playerInput = GetComponent<PlayerInput>();
    }

    private void Run()
    {
        //Use player input to translate the player
        Vector2 movement = playerInput.directionInput;
        float moveX = movement.x * speed * Time.deltaTime;
        float moveZ = movement.y * speed * Time.deltaTime;
        if (rb.position.y > zPosition && playerInput.directionInput.y < 0)
        {//While in the air, down key will not mean move backwards
            moveZ = 0f;
        }
        transform.Translate(moveX, 0f, moveZ);
    }

    private void Jump()
    {
        //When player starts to jump, record the start time, and add upward force.
        if (isGrounded && playerInput.startJumpInput)
        {
            jumpTimer = GameManager.instance.time;
            canJump = true;
            rb.velocity = Vector3.up * jumpForce;
        }

        //Player is in the air & wants to go down.
        if(rb.position.y > zPosition && playerInput.directionInput.y < 0)
        {
            rb.AddForce(Vector3.down/4, ForceMode.VelocityChange); 
        }

        //Player want to jump & is allow to if there is time.
        if (playerInput.jumpInput && canJump) 
        {
            if (GameManager.instance.time < jumpTimer + jumpTimeLimit)
            {
                rb.velocity = Vector3.up * jumpForce;
            } else
            {
                canJump = false;
            }

        }
        //Player stop pressing the space key
        if (playerInput.endJumpInput) canJump = false; 

        //Mario-like jump physics
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultipler - 1) * Time.deltaTime;
        }          

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Run();
        Jump();
    }
}
