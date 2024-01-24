using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer playerSpriteRenderer;
    private BoxCollider2D boxCollider;

    private float horizontalMovement;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float speed = 1000f;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSoundEffect;

    private enum MovementState { idle, running, jumping, falling }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // this works but not perfectlly, 'cause of the edges of the ground

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (!isTouchingGround && collision.collider.tag == "Ground")
    //     {
    //         isJumping = false;
    //         isTouchingGround = true;
    //     }
    // }
    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateAnimation();

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMovement * speed * Time.deltaTime, rb.velocity.y);

        // can't jump again when the player is in the air
        if (isGrounded() && (Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") == 1))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }
        // if (!isJumping && (Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") == 1))
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //     isJumping = true;
        //     isTouchingGround = false;
        // }


    }

    void UpdateAnimation()
    {
        MovementState state;
        if (horizontalMovement != 0f)
        {
            state = MovementState.running;
            playerSpriteRenderer.flipX = horizontalMovement < 0f;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);

    }

    bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
