using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    private float flyingTimer = 0.2f;

    private Rigidbody2D rb;

    [SerializeField]
    private Vector2 _direction;

    private float flyinySpeed = 10.0f;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        flyingTimer -= Time.deltaTime;

        if(flyingTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void setDirection(Vector2 target_direction)
    {
        direction = target_direction;
        rb.velocity = direction * flyinySpeed;
    }
    
}
