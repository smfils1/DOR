using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyCollision : MonoBehaviour
{
    private void Update() { }



    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SafeZone")
        {//Enemy hits the player's safezone. Decrease player mass & increase enemy mass
            float massLoss = Player.instance.GetComponent<Rigidbody>().mass / 5;
            if (massLoss >= 0.2)
            {
                Player.instance.GetComponent<Rigidbody>().mass -= massLoss;
            }
            GetComponent<Rigidbody>().mass += GameManager.instance.time;

        }
        else if (other.tag == "Boundary")
        {//Destroy the enemy if its outside the game boundary
            Destroy(gameObject);
        }
    }

}
