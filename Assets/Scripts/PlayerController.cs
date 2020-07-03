using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    // Movement Vars
    [Header("Movement Attr")]
    public float movementSpeed = 10.0f;
    public float jumpForce = 5.0f;
    public float jumpLimit = 2;
    private bool isFacingRight = false;

    // Physics Vars
    [Header("Physics Vars")]
    private Rigidbody2D rb;
    private float xDir;

    // Animation Vars
    [Header("Animation Vars")]
    Animator anim;

    // Ground and Jump Check Vars
    [Header("Ground and Jump check Vars")]
    public Transform ground;
    public LayerMask whatIsGround;
    public float groundRadius;
    private float currentJump = 0;
    public bool groundCheck;

    // Audio Vars
    [Header("Audio Refs")]
    public AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xDir * movementSpeed, rb.velocity.y);
        CheckEnv();
    }

    void Update()
    {
        if (GameManager.gm.isGameOver)
        {
            ClearPlayerEvents();
            SetAnimations();
            return;
        }
        xDir = Input.GetAxisRaw("Horizontal");
        HandleJump();
        SetAnimations();
    }

    private void HandleJump()
    {
        if (currentJump != jumpLimit && Input.GetButtonDown("Jump"))
        {
            ++currentJump;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.am.PlayJumpSound(audioSource);
        }
        else if (groundCheck && currentJump == jumpLimit) currentJump = 0;
    }

    private void SetAnimations()
    {
        if (groundCheck && xDir != 0 && rb.velocity.x != 0)
        {
            anim.SetBool("isRunning", true);
            if (audioSource && !audioSource.isPlaying) AudioManager.am.PlayFootstepSound(audioSource);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        anim.SetBool("groundCheck", groundCheck);
        anim.SetFloat("yVelocity", rb.velocity.y);
        if (isFacingRight && xDir == 1 || (!isFacingRight && xDir == -1)) FlipCharacter();
    }

    private void ClearPlayerEvents()
    {
        xDir = 0;
    }

    private void CheckEnv()
    {
        groundCheck = Physics2D.OverlapCircle(ground.position, groundRadius, whatIsGround);
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
