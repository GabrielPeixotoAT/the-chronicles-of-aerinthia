using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : Movement, EnemyController
{
    public float PerceptionDistance = 5;
    public float AttackDistance = 2;
    public float AttackSpeed = 1;
    public float FirstHitLate = 1;
    public int Lifes = 5;

    private bool isAttacking = false;
    private float waitAttack = 0;
    private bool isDead = false;

    private GameObject player;
    private Animator animator;
    private Rigidbody2D rigidbody;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(GameInfo.PlayerTag);
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null && !isDead)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance <= PerceptionDistance && distance > AttackDistance && !isAttacking)
            {
                Move();
            }
            else
            {
                StopMovement();
            }

            if (distance <= AttackDistance)
            {
                Attack();
            }
            else
            {
                if (isAttacking)
                    animator.SetBool("Attacking", false);

                isAttacking = false;
            }
        }
        else
        {
            StopMovement();
            StopAttack();
        }
    }

    void Move()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rigidbody.velocity = new Vector2(MovementSpeed * direction.x, rigidbody.velocity.y);

        if (direction.x > 0)
            transform.localScale = new Vector2(1, 1);
        else
            transform.localScale = new Vector2(-1, 1);

        animator.SetBool("Walking", true);
    }

    void StopMovement()
    {
        rigidbody.velocity = new Vector2(Vector2.zero.x, rigidbody.velocity.y);
        animator.SetBool("Walking", false);
    }

    void Attack()
    {
        if (!isAttacking)
            waitAttack = Time.time + FirstHitLate;

        if (waitAttack <= Time.time)
        {
            player.GetComponent<PlayerEntity>().TakeDamage();
            waitAttack = Time.time + AttackSpeed;
        }

        isAttacking = true;
        animator.SetBool("Attacking", true);
    }

    void StopAttack()
    {
        isAttacking = false;
        animator.SetBool("Attacking", false);
    }

    public void TakeDamage()
    {
        if (Lifes > 1)
        {
            Lifes--;
        }
        else
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetTrigger("Dead");
        Destroy(gameObject, 3);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<MaleeController>().enabled = false;
    }
}
