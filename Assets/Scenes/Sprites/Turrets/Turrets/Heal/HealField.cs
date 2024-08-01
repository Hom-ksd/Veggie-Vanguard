using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealField : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets =  new List<GameObject>();

    [SerializeField]
    private float healAmount = 10f;

    [SerializeField]
    private FloatingSpawnManager spawnManager;

    private StatusManager statusManager;

    private void Awake()
    {
        spawnManager = GetComponent<FloatingSpawnManager>();
        statusManager = GetComponentInParent<StatusManager>();
    }

    private void Start()
    {
        StartCoroutine(TriggerActionCoroutine());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            targets.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            targets.Remove(collision.gameObject);
        }
    }

    private void HealTriggerTarget()
    {
        spawnManager.Spawn();

        foreach (GameObject target in targets)
        {
            HealthSystem health_target = target.GetComponent<HealthSystem>();

            health_target.Heal(healAmount);
        }

        HealthSystem self_target  = gameObject.GetComponentInParent<HealthSystem>();
        
        self_target.Heal(healAmount);
    }

    IEnumerator TriggerActionCoroutine()
    {
        while (true)
        {
            targets.RemoveAll(target => target == null);

            if (statusManager.getPlacedStatus())
            {
                HealTriggerTarget();
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
}
