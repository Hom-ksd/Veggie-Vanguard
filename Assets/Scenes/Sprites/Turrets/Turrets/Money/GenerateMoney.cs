using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateMoney : MonoBehaviour
{
    [SerializeField]
    private MoneyManager moneyManager;
    [SerializeField]
    private FloatingSpawnManager spawnManager;

    [SerializeField]
    private float money_amount;

    private StatusManager statusManager;

    private void Awake()
    {
        moneyManager = GameObject.FindObjectOfType<MoneyManager>();
        spawnManager = gameObject.GetComponentInChildren<FloatingSpawnManager>();
        statusManager = gameObject.GetComponent<StatusManager>();
    }

    private void Start()
    {
        StartCoroutine(ExecuteEvery30Seconds());
    }

    private IEnumerator ExecuteEvery30Seconds()
    {
        while (true)
        {
            if (statusManager.getPlacedStatus())
            {
                generateMoney();
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void generateMoney()
    {
        moneyManager.addMoney(money_amount);
        spawnManager.Spawn();
    }
}
