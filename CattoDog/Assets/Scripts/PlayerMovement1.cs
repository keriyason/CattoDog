using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed = 5f; //speed of the player
    public float mouseSens = 100f; //mouse sensitivity 

    public float jumpForce = 5f; //jump amount
    public LayerMask mapMask; //ground layer
    public float groundCheckDistance = 1.1f; // checks if the player is on the ground

    static readonly int jumpAnim = Animator.StringToHash("Jump");
    static readonly int walkAnim = Animator.StringToHash("Walk");
    static readonly int idleAnim = Animator.StringToHash("Idle");

    private int extraJumps;
    public int extraJumpsValue;

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
        HandleJump();
    }
    void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal"); // moves left and right with A/D
        float z = Input.GetAxisRaw("Vertical"); // moves up and down with W/S

        Vector3 move = transform.right * x + transform.forward * z;
        //animator.Play(walkAnim);

        if (!IsGrounded) // in air
        {
            animator.Play(jumpAnim);
        }
        else // on ground
        {
            if (move.magnitude > 0)
            {
                animator.Play(walkAnim);
                print("walking");
            }
            else
            {
                animator.Play(idleAnim);
                print("not walking");

            }
        }




            rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }

    void RotatePlayer()
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
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                extraJumps--;
            }
        }

    }
    public bool IsGrounded;
   
    public bool CheckGrounded() => Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, mapMask);

}

