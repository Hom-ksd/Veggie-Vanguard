using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowField : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();

    private StatusManager statusManager;

    private void Awake()
    {
        statusManager = GetComponentInParent<StatusManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            targets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            targets.Remove(collision.gameObject);

            collision.gameObject.GetComponent<MoveEnemy>().isSlowed = false;
        }
    }

    private void Update()
    {
        if (statusManager.getPlacedStatus())
        {
            Slow();
        }
    }

    private void Slow()
    {
        targets.RemoveAll(target => target == null);

        foreach (GameObject target in targets)
        {
            target.GetComponent<MoveEnemy>().isSlowed = true;
        }
    }
}
