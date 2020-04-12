using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameManager gameManager;

    private void Awake()
    {
        playerMovement = GetComponent <PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        string other = collision.transform.tag;
        if (other == "Ground")
        {//When player hits the ground, it on the ground
            playerMovement.isGrounded = true;
        } else if (other == "Enemy")
        {//When player hits the enemy, increase score
            Score.instance.AddScore(5);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        string other = collision.transform.tag;
        if (other == "Ground")
        {//When the player leaves the ground, its off the ground
            playerMovement.isGrounded = false;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {//When the player leaves the boundary, kill it
            gameManager.isGameOver = true;
            gameManager.EndGame();
        }
    }

}
