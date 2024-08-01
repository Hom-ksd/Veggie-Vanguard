using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperFlying : MonoBehaviour
{
    [SerializeField]
    private Vector2 direction = Vector2.zero;

    [SerializeField]
    private float speed;

    private Rigidbody2D rb;

    Camera mainCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    private void Start()
    {
        rb.velocity = speed * direction;
    }

    private void Update()
    {
        Vector3 positionToCheck = transform.position;
        if (IsPositionOutOfScreen(positionToCheck))
        {
            Destroy(gameObject);
        }
    }
    public void SetDirection(Vector3 target_position)
    {
        direction = target_position - transform.position;
        direction = direction.normalized;

        RotateToward();
    }

    private bool IsPositionOutOfScreen(Vector3 position)
    {
        // Convert world position to screen position
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(position);

        // Check if the position is outside the screen bounds
        if (screenPosition.x < 0 || screenPosition.x > Screen.width ||
            screenPosition.y < 0 || screenPosition.y > Screen.height ||
            screenPosition.z < 0)
        {
            return true;
        }
        return false;
    }

    private void RotateToward()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

}
