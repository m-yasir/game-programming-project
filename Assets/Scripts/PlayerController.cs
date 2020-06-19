using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    // Movement Vars
    public float movementSpeed = 10.0f;
    public float jumpForce = 5.0f;
    public float jumpLimit = 2;
    private bool isFacingRight = false;

    // Physics Vars
    private Rigidbody2D rb;
    private float xDir;

    // Animation Vars
    Animator anim;

    // Ground and Jump Check Vars
    public Transform ground;
    public LayerMask whatIsGround;
    public float groundRadius;
    private float currentJump = 0;
    public bool groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        handleJump();
        setAnimations();
    }

    private void handleJump()
    {
        if (currentJump != jumpLimit && Input.GetButtonDown("Jump"))
        {
            ++currentJump;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (groundCheck && currentJump == jumpLimit) currentJump = 0;
    }

    private void setAnimations()
    {
        if (groundCheck && xDir != 0 && rb.velocity.x != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (isFacingRight && xDir == 1 || (!isFacingRight && xDir == -1)) flipCharacter();
    }

    private void checkEnv()
    {
        groundCheck = Physics2D.OverlapCircle(ground.position, groundRadius, whatIsGround);
    }

    private void flipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xDir * movementSpeed, rb.velocity.y);
        checkEnv();
    }
}
