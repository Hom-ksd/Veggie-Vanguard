using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private Coroutine repeatingCoroutine;

    [SerializeField]
    private GameObject target;

    public bool isAttacking = false;

    private void FixedUpdate()
    { 
        if(target != null && !isAttacking)
        {
            isAttacking = true;
        }
        else if(target == null && repeatingCoroutine != null)
        {
            StopCoroutine(repeatingCoroutine);
        }

        if(target == null)
        {
            isAttacking = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<StatusManager>().getIsAttackedAble() && target == null)
        { 
            repeatingCoroutine = StartCoroutine(TriggerEvery1Sec());
            target = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
    }
    private IEnumerator TriggerEvery1Sec()
    {
        while (true)
        {
            if (isAttacking)
            {
                if (target.GetComponent<StatusManager>().getPlacedStatus()) { 
                    Damage();
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void Damage()
    {
        HealthSystem health_target = target.GetComponent<HealthSystem>();

        bool isAttackedAble = target.GetComponent<StatusManager>().getIsAttackedAble();

        if (health_target != null && isAttackedAble)
        {
            health_target.TakeDamege(damage);
        }
    }
}
