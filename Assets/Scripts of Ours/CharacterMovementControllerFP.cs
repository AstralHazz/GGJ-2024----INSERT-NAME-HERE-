using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementControllerFP : MonoBehaviour
{
    //basic movement var declaration

    //Keybinds
    [Header("KeyBinds")]
    public KeyCode jumpKey = KeyCode.Space;

    //basics
    [Header("Movement")]
    public float movementSpeed;
    public float groundDrag;

    //gravity and ground check variables here
    [Header("Ground")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool onGround;

    // Jump variable declarations
    public float jumpPower;
    public float jumpCooldown;
    public float inAirMultiplier;
    public bool jumpReady;

    //orientation declaration
    public Transform orientation;

    //input variable declaration
    float hInput;
    float vInput;

    //direction and rigidbody
    Vector3 movementDirection;
    Rigidbody rigidBody;

    //start event
    private void Start()
    {
        //get the rigidbody here
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }

    //Movement functions
    private void playerInput()
    {
        //get the input here. call this in void update
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        //jump time
        if (Input.GetKey(jumpKey) && jumpReady && onGround)
        {
            Jump();
            jumpReady = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void movePlayer()
    {
        //actally make the movment happen here
        movementDirection = (orientation.forward * vInput) + (orientation.right * hInput);

        //on the ground movement
        if (onGround)
        {
            rigidBody.AddForce(movementDirection.normalized * movementSpeed * 5f, ForceMode.Force);
        }
        //in air(jumping/falling)
        else if (!onGround)
        {
            rigidBody.AddForce(movementDirection.normalized * movementSpeed * 5f * inAirMultiplier, ForceMode.Force);
        }
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);

        //speed limit enforced here
        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            rigidBody.velocity = new Vector3(limitedVel.x, rigidBody.velocity.y, limitedVel.z);
        }
    }
    //Jumping
    private void Jump()
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);
        rigidBody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        jumpReady = true;
    }
    // updates
    private void Update()
    {
        playerInput();
        speedControl();
        //ground check here
        onGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + .5f, whatIsGround);

        //do drag here
        if (onGround)
            rigidBody.drag = groundDrag;
        else
            rigidBody.drag = 0f;
    }
    private void FixedUpdate()
    {
        movePlayer();
    }
}
