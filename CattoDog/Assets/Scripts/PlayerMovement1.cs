using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed = 5f; //speed of the player
    public float mouseSens = 100f; //mouse sensitivity
    public float fallingGravity = 25f; 
    public float lowJumpGravity = 15f;

    public float jumpForce = 5f; //jump amount
    public LayerMask mapMask; //ground layer
    public float groundCheckDistance = 1.1f; // checks if the player is on the ground

    static readonly int jumpAnim = Animator.StringToHash("Jump"); // jump animation
    static readonly int walkAnim = Animator.StringToHash("Walk"); // walk animation
    static readonly int idleAnim = Animator.StringToHash("Idle"); // idle animation

    private int extraJumps; // adds an extra jump
    public int extraJumpsValue; // how many extra jumps
    public float extraJumpBoost = 3f;

    public Animator animator;

    private Rigidbody rb; 
   

    void Start()
    {
        extraJumps = extraJumpsValue; 
        Cursor.lockState = CursorLockMode.Locked; // locks the cursor to the center of the screen
        rb = GetComponent<Rigidbody>(); 
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        MovePlayer(); //Movement for player
    }

    private void Update()
    {
        IsGrounded = CheckGrounded();
        RotatePlayer(); // camera rotation with mouse
        HandleJump(); // jumping mechanic
    }
    void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal"); // moves left and right with A/D
        float z = Input.GetAxisRaw("Vertical"); // moves up and down with W/S

      
     

        Vector3 move = transform.right * x + transform.forward * z;
        

        if (!IsGrounded) // in air
        {
            animator.Play(jumpAnim); //plays jumping animation
        }
        else // on ground
        {
            if (move.magnitude > 0) // if the player ismoving play walking animation
            {
                animator.Play(walkAnim);
                print("walking");
            }
            else // if not revert to idle animation
            {
                animator.Play(idleAnim);
                print("not walking");

            }
        }

        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = move * speed;


       
        rb.velocity = new Vector3(targetVelocity.x, currentVelocity.y, targetVelocity.z);

        if (!IsGrounded) // handles jumping gravity
        {
            if (rb.velocity.y < 0)
            {
                rb.AddForce(Vector3.down * fallingGravity, ForceMode.Acceleration);
            }
            else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.down * lowJumpGravity, ForceMode.Acceleration);
            }
        } 
    }

    void RotatePlayer() //move the player in the direction that the mouse is facing
    {
       float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
    }
    void HandleJump()
    {
        {
            
            if (IsGrounded) 
            {
                extraJumps = extraJumpsValue; 
            }

            
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded) //space bar jump - checks if on ground
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            
            else if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) //accounts for double jump
            {
                rb.AddForce(Vector3.up * extraJumpBoost, ForceMode.Impulse);
                extraJumps--;
            }
        }

    }
    public bool IsGrounded; //checks for ground 
   
    public bool CheckGrounded() => Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, mapMask);

}

