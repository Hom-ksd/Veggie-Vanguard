using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    private float _money = 0.0f;

    public void addMoney(float amount)
    {
        _money += amount;
    }

    public void spendMoney(float amount)
    {
        if(amount <= _money)
        {
            _money -= amount;
        }
    }

    public float GetMoney()
    {
        return _money;
    }

    public bool CheckMoney(float amount)
    {
        if (amount > _money)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void Start()
    {
        StartCoroutine(ExecuteEvery30Seconds());
    }

    private IEnumerator ExecuteEvery30Seconds()
    {
            yield return new WaitForSeconds(5f);

            generateMoney();
    }

    private void generateMoney()
    {
        addMoney(50f);
    }
}
