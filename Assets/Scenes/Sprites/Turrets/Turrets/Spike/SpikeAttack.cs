using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject spikePrefab;

    [SerializeField]
    private Transform spikeSpawnPoint;

    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();

    [SerializeField]
    private bool isAttacking = false;

    [SerializeField]
    private float attackCooldown = 0.3f;
    [SerializeField]
    private float attackTimer = 0f;

    private StatusManager statusManager;

    private List<Vector2> directions = new List<Vector2>();

    private void Awake()
    {
        directions.Add(new Vector2(1, 1));   // Up-Right
        directions.Add(new Vector2(0, 1));   // Up C
        directions.Add(new Vector2(-1, 1));  // Up-Left
        directions.Add(new Vector2(-1, 0));  // Left
        directions.Add(new Vector2(-1, -1)); // Down-Left
        directions.Add(new Vector2(0, -1));  // Down C
        directions.Add(new Vector2(1, -1));  // Down-Right
        directions.Add(new Vector2(1, 0));   // Right

        statusManager = gameObject.GetComponentInParent<StatusManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            targets.Add(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (statusManager.getPlacedStatus())
        {
            if (targets.Count > 0)
            {
                targets.RemoveAll(target => target == null); 
            }

            if (targets.Count > 0 && !isAttacking)
            {
                isAttacking = true;
            }

            if (targets.Count <= 0)
            {
                isAttacking = false;
            }
            
            if (isAttacking)
            {
                if(attackTimer <= 0f)
                {
                    Attack();
                    attackTimer = attackCooldown;
                }
            }
            
            attackTimer -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        for (int angle = 0; angle < 360; angle += 45)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject spike = Instantiate(spikePrefab, spikeSpawnPoint.transform.position, rotation);

            SpikeMove move = spike.GetComponent<SpikeMove>();

            move.setDirection(directions[angle/45].normalized);
        }
    }


}
