using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Movement
{
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    private Rigidbody2D rigidbody2d;
    private Collider2D collider2d;
    private Animator animator;

    public float InputView;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = CheckGrounded();

        if (Time.deltaTime != 0)
        {
            animator.SetBool("IsGrounded", isGrounded);

            Move();

            if (isGrounded && (Input.GetKeyDown(KeyCode.UpArrow) ||
                Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.W)))
            {
                Jump();
            }
        }
    }

    bool CheckGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }

    public void Move()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        InputView = horizontalMovement;

        if (horizontalMovement != 0)
        {
            rigidbody2d.velocity = new Vector2(horizontalMovement * MovementSpeed, rigidbody2d.velocity.y);
            transform.localScale = new Vector2(horizontalMovement, 1);

            if (isGrounded)
                animator.SetBool("Runnig", true);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);

            if (isGrounded)
                animator.SetBool("Runnig", false);
        }
    }

    public void Jump()
    {
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, JumpForce);
        animator.SetBool("Runnig", false);

        animator.SetTrigger("Jump");
    }
}
