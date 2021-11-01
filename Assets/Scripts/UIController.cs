using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private TMP_Text speedText;
    
    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        DateTime startTime = DateTime.Now;
        
        while (true)
        {
            yield return null;
            
            timeText.text = $"{DateTime.Now - startTime:mm\\:ss}";
        }
    }

    public void UpdateProgress(float progress)
    {
        progressText.text = $"Progress: {progress}";
    }

    public void SetHealth(float health)
    {
        healthText.text = $"Health: {health}";
    }

    public void UpdateSpeed(float speed)
    {
        speedText.text = $"Speed: {speed:F}";
    }
}