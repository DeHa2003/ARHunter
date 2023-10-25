using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ARCamera : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;


    [SerializeField] private GameObject shotButton;
    [SerializeField] private float maxAngleSpeed;
    [SerializeField] private float maxVelocitySpeed;

    public float speedVelocity;
    public float speedAngle;
    public UnityEvent OnMaxValuesSpeed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void Update()
    {
        speedAngle = rb.angularVelocity.magnitude;
        speedVelocity = rb.velocity.magnitude;

        if(rb.angularVelocity.magnitude <= maxAngleSpeed || rb.velocity.magnitude <= maxVelocitySpeed)
        {
            shotButton.SetActive(true);
            OnMaxValuesSpeed?.Invoke();
        }
        else
        {
            shotButton.SetActive(false);
        }

        text1.text = Input.acceleration.x.ToString();
        text2.text = Input.acceleration.y.ToString();
        text3.text = Input.acceleration.z.ToString();
    }
}
