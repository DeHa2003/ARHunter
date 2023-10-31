using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public static Action OnFinishTimer;
    [SerializeField] private TextMeshProUGUI textTime;
    [SerializeField] private float time;
    private bool isPlaying = false;
    private void OnEnable()
    {
        OnTargetEvents.onTargetFound += PlayTimer;
        OnTargetEvents.onTargetLost += StopTimer;
    }

    private void OnDisable()
    {
        OnTargetEvents.onTargetFound -= PlayTimer;
        OnTargetEvents.onTargetLost -= StopTimer;
        
    }

    public void PlayTimer()
    {
        isPlaying = true;
    }

    public void StopTimer()
    {
        isPlaying = false;
    }

    private void Update()
    {
        if (isPlaying)
        {
            time -= Time.deltaTime;
            if(time > 1)
            {
                int minutes = Mathf.FloorToInt(time / 60);
                int seconds = Mathf.FloorToInt(time % 60);
                textTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {

                OnFinishTimer?.Invoke();
                Destroy(textTime.gameObject);
            }
        }
    }

    public string GetTextTime()
    {
        return textTime.text;
    }
}
