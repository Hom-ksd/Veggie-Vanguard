using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplayManager : MonoBehaviour
{
    [SerializeField]
    private HealthSystem healthSystem;

    [SerializeField]
    private Slider healthBarSlider;

    private void Awake()
    {
        healthSystem = gameObject.GetComponent<HealthSystem>();
    }

    private void Start()
    {
        healthBarSlider.maxValue = healthSystem.maxHealth;
    }

    private void Update()
    {
        healthBarSlider.value = healthSystem.healthPoint;

        if(healthSystem.maxHealth == healthSystem.healthPoint)
        {
            healthBarSlider.gameObject.SetActive(false);
        }
        else
        {
            healthBarSlider.gameObject.SetActive(true);
        }
    }
}
