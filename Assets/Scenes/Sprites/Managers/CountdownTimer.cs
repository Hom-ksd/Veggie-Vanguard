using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField]
    private float countdownTime = 180f; // 3 minutes in seconds

    [SerializeField]
    private TMP_Text timerText; // Reference to the TextMeshPro text component

    [SerializeField]
    private float timeRemaining;

    private void Start()
    {
        timeRemaining = countdownTime;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timeRemaining = 0;
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        timerText.text = $"{minutes:D2}:{seconds:D2}";
    }

    public bool IsTimeRemaining()
    {
        return timeRemaining > 0;
    }
}
