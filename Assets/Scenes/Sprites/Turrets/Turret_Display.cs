using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret_Display : MonoBehaviour
{
    public Turret turret;

    public SpriteRenderer Top;
    public SpriteRenderer Bottom;

    private void Awake()
    {
        Top.sprite = turret.topSprite;
        Bottom.sprite = turret.bottomSprite;
    }

    public float GetCost()
    {
        return turret.cost;
    }
}
