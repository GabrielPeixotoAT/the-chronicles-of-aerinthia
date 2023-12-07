using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Movement
{
    public float AttackRange;
    public float AttackSpeed;

    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public LayerMask EnemyLayer;

    private float waitAttack;

    private Rigidbody2D rigidbody2d;
    private Animator animator;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = CheckGrounded();

        if (Time.deltaTime != 0)
        {
            animator.SetBool("IsGrounded", isGrounded);

            if (waitAttack <= Time.time)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                     Attack();
                }
                else
                {
                    Move();
                }

                if (isGrounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
                {
                    Jump();
                }
            }   
        }
    }

    bool CheckGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }

    public void Stop()
    {
        rigidbody2d.velocity = Vector2.zero;
        animator.SetBool("Runnig", false);
    }

    public void Move()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

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

    private void Attack()
    {
        waitAttack = Time.time + AttackSpeed;
        animator.SetTrigger("Attack");

        Vector2 directionRay = new Vector2(transform.localScale.x, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionRay, AttackRange, EnemyLayer);

        if (hit.collider != null)
        {
            var enemyController = hit.collider.gameObject.GetComponent<EnemyController>();

            enemyController.Die();
        }
    }

    public void TriggerHitAnimation()
    {
        animator.SetTrigger("TakeHit");
    }
}
