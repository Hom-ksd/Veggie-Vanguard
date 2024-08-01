using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritecollisionManager : MonoBehaviour
{
    [SerializeField]
    private HealthSystem selfHealthSystem;


    private void Awake()
    {
        selfHealthSystem = GetComponent<HealthSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            float damage = collision.gameObject.GetComponent<HealthSystem>().getHealthPoint();

            selfHealthSystem.TakeDamege(damage);

            Destroy(collision.gameObject);
        }
    }
}
