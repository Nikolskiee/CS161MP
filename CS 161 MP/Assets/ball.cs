using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Vector3 jump;
    public Vector3 forwardSpeed;
    public Vector3 sideRight;
    public Vector3 sideLeft;


    private bool hasStarted = false;
    private bool onAir = false;
    private int col = 0;

    private bool goJump = false;
    private bool goLeft = false;
    private bool goRight = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) { // to start moving the ball, does nothing when pressed again
            hasStarted = true;
            Debug.Log("Start");
        }

        if((col > -1) && (Input.GetKeyDown(KeyCode.A))) { // to move the ball on the left

            goLeft = true;
            Debug.Log("Left");
        }

        if((col < 1) && (Input.GetKeyDown(KeyCode.D))) { // to move the ball to the right

            goRight = true;
            Debug.Log("Right");
        }

        if(Input.GetKeyDown(KeyCode.Space)){ // ball jump
            goJump = true;
            Debug.Log("Jump!");
        }


    }

    // FixedUpdate is called once per frame.
    void FixedUpdate() {
        if(hasStarted == true) {
            transform.position += forwardSpeed;
        }

        if(goLeft) {
            transform.position += sideLeft;
            col -= 1;
            goLeft = false;
        }

        if(goRight) {

            transform.position += sideRight;
            col += 1;
            goRight = false;
        }

        if(goJump) {
            onAir = true;
            transform.position += jump;
            goJump = false;
        }

    }
}
