using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAnimations : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    public void PlaySound(AudioClip audioClip)
    {
        source.clip = audioClip;
        source.Play();
    }
}
