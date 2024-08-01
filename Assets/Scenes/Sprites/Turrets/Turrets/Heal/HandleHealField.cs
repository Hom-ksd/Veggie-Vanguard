using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleHealField : MonoBehaviour
{
    [SerializeField]
    private Collider2D healField;

    [SerializeField]
    private StatusManager statusManager;

    private void Awake()
    {
        statusManager = GetComponentInParent<StatusManager>();
        healField = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!statusManager.getPlacedStatus())
        {
            healField.enabled = false;
        }
        else
        {
            healField.enabled = true;
        }
    }
}
