using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SniperDamage : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage(collision.gameObject);
        }
    }

    private void Damage(GameObject target)
    {
        HealthSystem health_target = target.GetComponent<HealthSystem>();

        health_target.TakeDamege(damage);

        Destroy(gameObject);
    }
}
