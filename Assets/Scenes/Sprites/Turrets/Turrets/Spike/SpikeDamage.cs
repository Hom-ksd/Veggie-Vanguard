using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpikeDamage : MonoBehaviour
{
    private GameObject target;

    private float damage = 15.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            target = collision.gameObject;

            DamageTriggerTarget();
        }
    }

    private void DamageTriggerTarget()
    {
        HealthSystem health_target = target.GetComponent<HealthSystem>();

        health_target.TakeDamege(damage);
    }
}
