using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{//Get all user inputs
    public Vector2 directionInput { get; private set; }
    public bool startJumpInput { get; private set; }
    public bool endJumpInput { get; private set; }
    public bool jumpInput { get; private set; }


    // Update is called once per frame
    void Update()
    {
        directionInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        startJumpInput = Input.GetKeyDown(KeyCode.Space);
        endJumpInput = Input.GetKeyUp(KeyCode.Space);
        jumpInput = Input.GetKey(KeyCode.Space);
    }
}
