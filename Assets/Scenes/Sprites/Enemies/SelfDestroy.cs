using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField]
    private float damage = 10f;

    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();

            healthSystem.TakeDamege(damage);
        }
    }   

    private void Update()
    {
        targets.RemoveAll(target => target == null);
    }
}
