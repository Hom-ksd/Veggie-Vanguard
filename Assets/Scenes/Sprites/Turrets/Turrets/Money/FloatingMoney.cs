using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMoney : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = new Vector2 (0, speed);

        StartCoroutine(DeleteAfterDelay());
    }

    // Coroutine to wait for 1 second and then delete the GameObject
    IEnumerator DeleteAfterDelay()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Delete the GameObject
        Destroy(gameObject);
    }
}
