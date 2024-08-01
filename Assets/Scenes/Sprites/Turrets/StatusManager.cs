using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [SerializeField]
    private bool isPlaced = false;

    public bool getPlacedStatus()
    {
        return isPlaced;
    }

    public void setPlacedStatus(bool status)
    {
        isPlaced = status;
    }

    [SerializeField]
    private bool isAttackedAble = false;

    public bool getIsAttackedAble()
    {
        return isAttackedAble;
    }

    public void setIsAttackAble(bool status)
    {
        isAttackedAble = status;
    }

    [SerializeField]
    private bool isOutOfRange = true;

    public void setOutOfRange(bool status)
    {
        isOutOfRange = status;
    }

    public bool getOutOfRange()
    {
        return isOutOfRange;
    }
}
