using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public Transform isGroundedChecker;
    public LayerMask groundLayer;
    Rigidbody2D rb;
    SpriteRenderer sr;

    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float checkGroundRadius;
    public float rememberGroundedFor;
    float lastTimeGrounded;

    bool isGrounded = false;

    public int defaultAdditionalJumps = 1;
    int additionalJumps;


    void Start()
    {
        // Get components
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // Set default value of additionalJumps
        additionalJumps = defaultAdditionalJumps;
    }

    void Update()
    {
        Move();
        Jump();
        SmoothenJump();
        CheckIfGrounded();
    }

    // Makes the player move left and right
    void Move()
    {
        // Get the horizontal axis on the input, this is either -1 or 1, multiply this with the speed and give this to the velocity of the rigidbody
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        // Flip the sprite depending on the direction the player is moving
        if (x == 1)
            sr.flipX = true;
        else if (x == -1)
            sr.flipX = false;
    }

    // Makes the player jump
    void Jump()
    {
        // Give the rigidbody jumpforce (vertical speed) when space is pressed AND the player is on the ground AND the time to jump again is not passed yet(for when double jumping is enabled)
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            additionalJumps--;
        }
    }

    // Smoothens the player jump
    void SmoothenJump()
    {
        // Make the gravity smoother depending on the vertical velocity of the player
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    // Checks if the player is on the ground or airborne
    void CheckIfGrounded()
    {
        // Creates a imaginary circle that will handle the collision
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        // If there are no colliders, player is grounded and jumps are default
        if (colliders != null)
        {
            isGrounded = true;
            additionalJumps = defaultAdditionalJumps;
        }
        // Else if the player is grounded, update the lastTimeGrounded, and make isGrounded false
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

}