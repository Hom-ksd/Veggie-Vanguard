using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SelfRegeneration : MonoBehaviour
{
    [SerializeField]
    private HealthSystem healthSystem;

    [SerializeField]
    private float healAmount = 10f;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        StartCoroutine(TriggerActionCoroutine());
    }

    private void HealTriggerTarget()
    {
        healthSystem.Heal(healAmount);
    }

    IEnumerator TriggerActionCoroutine()
    {
        while (true)
        {
            HealTriggerTarget();

            yield return new WaitForSeconds(1.0f);
        }
    }
}
