using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetTimeAndScore : MonoBehaviour
{
    [SerializeField] private GameObject panelData;

    [Header("GetTimer")]
    [SerializeField] private Timer timer;
    [SerializeField] private TextMeshProUGUI textTimer;

    [Header("GetScore")]
    [SerializeField] private Score scoreData;
    [SerializeField] private TextMeshProUGUI textScore;

    private void OnEnable()
    {
        if (textTimer.text != timer.GetTextTime())
        {
            panelData.SetActive(true);

            textTimer.text = timer.GetTextTime();
            textScore.text = scoreData.GetScore();
        }
    }

    private void OnDisable()
    {
        panelData.SetActive(false);
    }

}
