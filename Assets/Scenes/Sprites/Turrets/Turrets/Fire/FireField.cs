using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireField : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();

    [SerializeField]
    private GameObject firePrefab;

    [SerializeField]
    private string targetTag = "FireEffect";

    [SerializeField]
    private float damage;

    [SerializeField]
    private StatusManager placedStatus;

    [SerializeField]
    private Collider2D selfCollider;

    private void Awake()
    {
        placedStatus = gameObject.GetComponentInParent<StatusManager>();

        selfCollider = gameObject.GetComponent<Collider2D>();
    }

    private void Start()
    {
        StartCoroutine(TriggerActionCoroutine());
    }

    private void Update()
    {
        if (!placedStatus.getPlacedStatus())
        {
            selfCollider.enabled = false;
        }
        else
        {
            selfCollider.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject target = collision.gameObject;

        targets.Add(target);

        GameObject fire = Instantiate(firePrefab, target.transform.position, Quaternion.identity);

        fire.transform.SetParent(target.transform);

        fire.transform.localPosition = Vector3.zero;

        fire.transform.localRotation = Quaternion.identity;

        fire.transform.localScale = Vector3.one;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        GameObject target = collision.gameObject;

        GameObject child = GetChildWithTag(target, targetTag);

        Destroy(child);

        targets.Remove(target);
    }

    private GameObject GetChildWithTag(GameObject parent, string tag)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.CompareTag(tag))
            {
                return child.gameObject;
            }
        }
        return null;
    }

    private void DamageTriggerTarget()
    {
        foreach (GameObject target in targets)
        {
            HealthSystem health_target = target.GetComponent<HealthSystem>();

            health_target.TakeDamege(damage);
        }
    }

    IEnumerator TriggerActionCoroutine()
    {
        while (true)
        {
            if (placedStatus.getPlacedStatus())
            {
                DamageTriggerTarget();
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
}
