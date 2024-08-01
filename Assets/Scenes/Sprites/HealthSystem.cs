using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float _healthPoint;

    [SerializeField]
    private float _maxHealth;

    public float healthPoint
    {
        get { return _healthPoint; }
        set { _healthPoint = value; }
    }

    public float maxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public void TakeDamege(float amount)
    {
        healthPoint -= amount;
    }

    public void Heal(float amout)
    {
        healthPoint = Mathf.Min(healthPoint + amout, maxHealth);
    }

    private void Awake()
    {
        healthPoint = maxHealth;
    }

    private void Update()
    {
        if (healthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float getHealthPoint()
    {
        return healthPoint;
    }
}
