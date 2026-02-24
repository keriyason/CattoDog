using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed = 5f;              // ground speed
    public float airSpeed = 8f;           // faster movement in air
    public float mouseSens = 100f;        // mouse sensitivity
    public float fallingGravity = 25f;    // stronger gravity when falling

    public float jumpForce = 5f;          // jump amount
    public LayerMask mapMask;             // ground layer
    public float groundCheckDistance = 1.1f; //groumd check

    static readonly int jumpAnim = Animator.StringToHash("Jump"); //calls to animations for Jump, Walk, and Idle
    static readonly int walkAnim = Animator.StringToHash("Walk");
    static readonly int idleAnim = Animator.StringToHash("Idle");

    public Animator animator;

    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        IsGrounded = CheckGrounded();
        RotatePlayer();
        HandleJump();
    }

    void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

      
        if (!IsGrounded) // call to when each animation triggers 
        {
            animator.Play(jumpAnim);
        }
        else
        {
            if (move.magnitude > 0)
                animator.Play(walkAnim);
            else
                animator.Play(idleAnim);
        }

        
        float currentSpeed = IsGrounded ? speed : airSpeed;

        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = move * currentSpeed;

        rb.velocity = new Vector3(targetVelocity.x, currentVelocity.y, targetVelocity.z);

        
        if (!IsGrounded && rb.velocity.y < 0) //extra gravity for falling = faster falling
        {
            rb.AddForce(Vector3.down * fallingGravity, ForceMode.Acceleration);
        }
    }

    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public bool IsGrounded;

    public bool CheckGrounded() =>
        Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, mapMask);
}