using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSounds : MonoBehaviour
{
    [SerializeField] private AudioSource mapSource;

    [SerializeField] private AudioClip audioClipLow;
    [SerializeField] private AudioClip audioClipFast;

    private void OnEnable()
    {
        DollyCartControl.OnFastSpeed += PlayFastSpeed;
        DollyCartControl.OnLowSpeed += PlayLowSpeed;
    }

    private void OnDisable()
    {
        DollyCartControl.OnFastSpeed -= PlayFastSpeed;
        DollyCartControl.OnLowSpeed -= PlayLowSpeed;
    }
    private void PlayFastSpeed()
    {
        PlaySound(audioClipFast);
    }

    private void PlayLowSpeed()
    {
        PlaySound(audioClipLow);
    }

    private void PlaySound(AudioClip audioClip)
    {
        mapSource.clip = audioClip;
        mapSource.Play();
    }
}
