using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public static float speed = 5f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Run()
    {//Add forward force to the enemy
        rb.AddForce(Vector3.back * speed);
    } 

    void FixedUpdate()
    {
        Run();
        speed += (Time.deltaTime * Time.deltaTime * 0.5f);
    }
}
