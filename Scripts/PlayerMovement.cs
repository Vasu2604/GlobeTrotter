using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float DirX = 0f;
    private BoxCollider2D coll;


    [SerializeField] private LayerMask JumpableGround;
    [SerializeField] float RunSpeed = 5f;
    [SerializeField] float jumpForce = 25f;

    [SerializeField] private AudioSource JumpSound;
    bool isAlive = true;

    private enum MovementState { idel, running, jumping, falling }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(DirX * RunSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGround())
        {
            JumpSound.Play();

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
        IsGround();

    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (DirX > 0f)
        {

            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (DirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idel;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }
}
