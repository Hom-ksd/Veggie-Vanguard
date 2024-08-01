using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> plantPrefabs = new List<GameObject>(); // List of plant prefabs

    [SerializeField]
    private MoneyManager moneyManager;

    [SerializeField]
    private MoneyVisualization moneyVisualization;

    [SerializeField]
    private GameObject turret;

    private float turretCost;

    public bool CheckInputForPlant(KeyCode key, int plantIndex)
    {
        if (Input.GetKeyDown(key) && plantIndex >= 0 && plantIndex < plantPrefabs.Count)
        {
            turretCost = plantPrefabs[plantIndex].GetComponent<Turret_Display>().GetCost();

            if (moneyManager.CheckMoney(turretCost))
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                mousePosition.z = 0;

                turret = Instantiate(plantPrefabs[plantIndex], mousePosition, Quaternion.identity);
                turret.AddComponent<FollowCursor>();
                turret.AddComponent<CheckCanBePlaced>();
                turret.AddComponent<ChangeToRed>();

                return true;
            }
            else
            {
                moneyVisualization.BlinkRedAndShake();

                return false;
            }
        }
        return false;
    }
}
