using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SniperAttack : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float AttackTimer;

    [SerializeField]
    private float AttackCooldown = 1.0f;

    [SerializeField]
    private Transform SniperSpawnPoint;

    [SerializeField]
    private GameObject SpinerPrefab;

    private StatusManager statusManager;

    private void Awake()
    {
        statusManager = gameObject.GetComponentInParent<StatusManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            targets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            targets.Remove(collision.gameObject);
        }
    }

    private void Start()
    {
        AttackTimer = AttackCooldown;
    }

    private void FixedUpdate()
    {
        targets.RemoveAll(target => target == null);

        if(AttackTimer <= 0 && targets.Count > 0 && statusManager.getPlacedStatus())
        {
            AttackTimer = AttackCooldown;

            Attack();
        }

        AttackTimer -= Time.deltaTime;
    }

    private void Attack()
    {   
        if (targets.Count > 0)
            target = targets[0];

        if (target != null)
        {
            GameObject bullet = Instantiate(SpinerPrefab, SniperSpawnPoint.transform.position, Quaternion.identity);

            SniperFlying sniperFlying = bullet.GetComponent<SniperFlying>();

            sniperFlying.SetDirection(target.transform.position);
        }
    }
}
