using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DollyCartControl : MonoBehaviour
{
    public static Action OnFastSpeed;
    public static Action OnLowSpeed;

    [SerializeField] private CinemachineDollyCart dollyCart;
    [SerializeField] private CinemachineSmoothPath smoothPath;

    [Header("Speed")]
    [SerializeField] private float timeBorderFastAndLow;
    [SerializeField] private Slider sliderSpeed;
    [SerializeField] private TextMeshProUGUI textSpeed;

    [Header("Loop")]
    [SerializeField] private GameObject imageCheckBox;

    private bool isFastSpeedGame = false;
    private bool isLowSpeedGame = true;
    private void Start()
    {
        sliderSpeed.value = dollyCart.m_Speed;
        textSpeed.text = dollyCart.m_Speed.ToString("0.0");
    }

    private void Update()
    {
        if(dollyCart.m_Speed != sliderSpeed.value)
        {
            dollyCart.m_Speed = sliderSpeed.value;
            textSpeed.text = dollyCart.m_Speed.ToString("0.0");

            if (Mathf.Abs(dollyCart.m_Speed) > timeBorderFastAndLow)
            {
                if (!isFastSpeedGame)
                {
                    OnFastSpeed.Invoke();

                    isFastSpeedGame = true;
                    isLowSpeedGame = false;
                }
            }
            else
            {
                if (!isLowSpeedGame)
                {
                    OnLowSpeed.Invoke();

                    isFastSpeedGame = false;
                    isLowSpeedGame = true;
                }
            }
        }
    }

    public void CheckLoopingPath()
    {
        if (!smoothPath.Looped)
        {
            smoothPath.m_Looped = true;
            imageCheckBox.SetActive(true);
        }
        else
        {
            smoothPath.m_Looped = false;
            imageCheckBox.SetActive(false);
        }
    }

    public void PlayingDollyCart(bool isPlaying)
    {
        dollyCart.enabled = isPlaying;
    }

    public void SkipDollyCart(float skip)
    {
        if(dollyCart.m_Speed>= 0)
        {
            dollyCart.m_Position += skip;
        }
        else
            dollyCart.m_Position += -skip;
    }
}
