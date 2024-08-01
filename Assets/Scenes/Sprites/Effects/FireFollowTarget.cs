using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFollowTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = target.transform.position;
    }
}
