using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyVisualization : MonoBehaviour
{
    [SerializeField]
    private MoneyManager moneyManger;

    [SerializeField]
    private TMP_Text moneyText;

    private Color originalColor;
    private Vector3 originalPosition;

    private void Awake()
    {
        moneyText = GetComponentInChildren<TMP_Text>();
        originalColor = moneyText.color;
        originalPosition = moneyText.transform.localPosition;
    }

    private void Update()
    {
        moneyText.text = moneyManger.GetMoney().ToString();
    }

    public void BlinkRedAndShake()
    {
        StartCoroutine(BlinkRedAndShakeCoroutine());
    }

    // Coroutine to handle the blinking and shaking effect
    private IEnumerator BlinkRedAndShakeCoroutine()
    {
        float shakeMagnitude = 10f; // Magnitude of the shake
        float shakeDuration = 0.2f; // Duration of the shake

        // Blink effect
        moneyText.color = Color.red;
        Vector3 originalPos = originalPosition;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float shakeOffset = Mathf.Sin(elapsedTime * Mathf.PI * 20) * shakeMagnitude;
            moneyText.transform.localPosition = new Vector3(originalPos.x + shakeOffset, originalPos.y, originalPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        moneyText.transform.localPosition = originalPos; // Reset position
        moneyText.color = originalColor; // Change color back to original
    }
}
