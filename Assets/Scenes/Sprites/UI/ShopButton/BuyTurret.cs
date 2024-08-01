using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyTurret : MonoBehaviour
{
    [SerializeField]
    private GameObject turretPrefab;

    [SerializeField]
    private MoneyManager moneyManager;

    [SerializeField]
    private MoneyVisualization moneyVisualization;

    [SerializeField]
    private TMP_Text text1;

    [SerializeField]
    private TMP_Text text2;

    private float turretCost;

    private GameStateManager gameStateManager;

    private void Awake()
    {
        moneyManager = FindAnyObjectByType<MoneyManager>();
        turretCost = turretPrefab.GetComponent<Turret_Display>().GetCost();
        gameStateManager = FindAnyObjectByType<GameStateManager>();
    }

    private void Start()
    {
        text1.text = turretCost.ToString();
        text2.text = turretCost.ToString();
    }

    public void OnClick()
    {
        if (!gameStateManager.IsBuying())
        {

            if (moneyManager.CheckMoney(turretCost))
            {
                gameStateManager.SetBuying(true);
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                mousePosition.z = 0;

                GameObject turret = Instantiate(turretPrefab, mousePosition, Quaternion.identity);
                turret.AddComponent<FollowCursor>();
                turret.AddComponent<CheckCanBePlaced>();
                turret.AddComponent<ChangeToRed>();
            }
            else
            {
                moneyVisualization.BlinkRedAndShake();
            }
        }
    }
}
