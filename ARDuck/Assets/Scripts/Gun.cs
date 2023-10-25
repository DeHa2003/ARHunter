using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float timePerezaryad;
    [SerializeField] private Quaternion posToPerezaryad;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioClip perezaryadSound;

    private ConfigurableJoint joint;
    private AudioSource audioSource;
    private Rigidbody rb;

    private void Awake()
    {
        joint = GetComponent<ConfigurableJoint>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Shot.onShot += OnShot;
        Shot.onPerezaryad += OnPerezaryad;
    }

    private void OnDisable()
    {
        Shot.onShot -= OnShot;
        Shot.onPerezaryad -= OnPerezaryad;
    }

    private void OnShot()
    {
        rb.AddTorque(transform.right * Random.Range(100, 1000));
        rb.AddForce(transform.forward * Random.Range(15, 30));
    }

    private void OnPerezaryad()
    {
        StartCoroutine(PlaySound(audioSource, perezaryadSound, 1.7f));
        joint.targetRotation = posToPerezaryad;
        Invoke(nameof(OffPerezaryad), timePerezaryad);

    }

    private void OffPerezaryad()
    {
        joint.targetRotation = new Quaternion(0, 0, 0, 0);
    }

    private IEnumerator PlaySound(AudioSource audioSource, AudioClip audioClip, float pause)
    {
        yield return new WaitForSeconds(pause);
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
