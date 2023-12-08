using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour, EnemyController
{
    public float PerceptionDistance = 5;
    public float AttackDistance = 2;
    public float AttackSpeed = 1;
    public float FirstHitLate = 1;

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

    public void Die()
    {
        animator.SetTrigger("Dead");
        Destroy(gameObject, 3);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<MaleeController>().enabled = false;
    }
}
