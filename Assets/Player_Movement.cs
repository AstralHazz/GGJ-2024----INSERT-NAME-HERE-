using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //different animations from enum 

    //local variables

    private float xAxis, yAxis, zAxis = 0.0f;

    private float Velocity = 2f;



    //player vector

    private Vector3 playerVector = new Vector3();

    private bool Moving = false;



    private bool iscolliding = false;



    //audio source

    AudioSource footsteps;


    //audio clip

    [SerializeField]

    AudioClip footStepClip;

    void Start()

    {

    }



    // Update is called once per frame

    void Update()

    {

        HandleMovement();

         

        /*
        if (Moving && !footsteps.isPlaying && iscolliding)

        {

            footsteps.PlayOneShot(footStepClip);

        }



        if (!Moving && iscolliding)
        {
            footsteps.Stop();
        }
        */
    }



    void HandleMovement()
    {

        float mouseXSpeed = Input.GetAxis("Mouse X") * 2.0f;

        Mathf.Clamp(Velocity, 2f, 4f);

        //set the positions to a variable that is changeable

        playerVector.x = xAxis;

        playerVector.y = yAxis;

        playerVector.z = zAxis;



        //input booleans

        bool MovingForwardInput = Input.GetKey(KeyCode.W);

        bool RunningInput = Input.GetKey(KeyCode.LeftShift);

        bool TurningLeftInput = Input.GetKey(KeyCode.A);

        bool TurningRightInput = Input.GetKey(KeyCode.D);

        bool MovingBackwardsInput = Input.GetKey(KeyCode.S);



        if (MovingForwardInput)

        {

            //positive or negative depending on mouse

            playerVector.z = 1;

            if (RunningInput)
            {

                Moving = false;

                if (TurningLeftInput)
                {

                    Velocity = 4f;

                    MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

                    MoveHorizontally(-1, Velocity);

                }

                else if (TurningRightInput)
                {

                    Velocity = 4f;

                    MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

                    MoveHorizontally(1, Velocity);

                }

                else
                {

                    Velocity = 4f;

                    MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

                }

            } 
            else if (TurningLeftInput)
            {

                Velocity = 2f;

                MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

                MoveHorizontally(-1, Velocity);

            }

            else if (TurningRightInput)
            {

                Velocity = 2f;

                MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

                MoveHorizontally(1, Velocity);

            }

            else
            {

                Moving = true;

                Velocity = 2f;

                MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

            }

        }

        else if (MovingBackwardsInput)

        {

            //positive or negative depending on mouse

            playerVector.z = -1;

            if (RunningInput)
            {

                Moving = false;

                if (TurningLeftInput)
                {
                    Velocity = 4f;

                    MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

                    MoveHorizontally(-1, Velocity);

                }

                else if (TurningRightInput)
                {

                    Velocity = 4f;

                    MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

                    MoveHorizontally(1, Velocity);

                }

                else
                {

                    Velocity = 4f;

                    MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

                }

            }
            else if (TurningLeftInput)
            {

                Velocity = 2f;

                MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

                MoveHorizontally(-1, Velocity);

            }

            else if (TurningRightInput)
            {

                Velocity = 2f;

                MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

                MoveHorizontally(1, Velocity);

            }

            else
            {

                Moving = true;

                Velocity = 2f;

                MoveInMouseDirection(playerVector, Velocity, mouseXSpeed);

            }

        }

        else if (TurningLeftInput)

        {

            Moving = true;

            MoveHorizontally(-1, Velocity);

        }

        else if (TurningRightInput)

        {

            Moving = true;

            MoveHorizontally(1, Velocity);

        }

        else

        {

            Velocity = 2f;

            Moving = false;

        }

    }



    //moves z, and y rotation based off shift/mouse

    void MoveInMouseDirection(Vector3 currentPlayerVector, float currentVelocity, float mouseSpeed)

    {

        transform.Translate(0, 0, currentPlayerVector.z * currentVelocity * Time.deltaTime);

        transform.Rotate(0.0f, mouseSpeed, 0.0f);

    }



    void MoveHorizontally(float currentPlayerVectorX, float currentVelocity)

    {

        playerVector.x = currentPlayerVectorX;

        playerVector.x *= currentVelocity;

        transform.Translate(playerVector.x * Time.deltaTime, 0, 0);

    }


    /*
    private void OnCollisionEnter(Collision collision)

    {

        GameObject beach = GameObject.Find("beach");

        BoxCollider beachCollider = beach.GetComponent<BoxCollider>();

        footsteps = gameObject.GetComponent<AudioSource>();



        ////play sounds for when the player feet touches the ground

        if (collision.collider == beachCollider)

        {

            iscolliding = true;

        }

    }
    */
}
