using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    public bool isAttacking;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Vector2 direction;

    private EnemyDamage enemyDamage;

    [SerializeField]
    private float slowMultiplier;

    public bool isSlowed = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        enemyDamage = transform.GetComponentInChildren<EnemyDamage>();
    }

    private void Start()
    {
        direction = (Vector3.zero - transform.position).normalized;
    }

    private void Update()
    {
        isAttacking = enemyDamage.isAttacking;
    }

    private void FixedUpdate()
    {
        if (isAttacking)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            if(isSlowed)
            {
                rb.velocity = direction * moveSpeed * new Vector2(slowMultiplier, slowMultiplier);
            }
            else
            {
                rb.velocity = direction * moveSpeed;
            }
        }
    }
}
