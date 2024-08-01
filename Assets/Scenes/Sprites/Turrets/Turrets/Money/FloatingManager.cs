using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FloatingSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject MoneyPrefab;
    [SerializeField] GameObject moneySpawnPosition;

    public void Spawn()
    {
        GameObject money = Instantiate(MoneyPrefab, moneySpawnPosition.transform.position, Quaternion.identity);
    }
}
