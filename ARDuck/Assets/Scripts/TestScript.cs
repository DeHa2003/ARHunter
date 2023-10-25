using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using static UnityEngine.GraphicsBuffer;

public class TestScript : MonoBehaviour
{
    public Transform target;

    public float speedRotation;
    private Quaternion rotGoal;
    private Vector3 direction;
    private void Update()
    {
        CheckRotation();
    }

    private void CheckRotation()
    {
        direction = (target.position - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, speedRotation * Time.deltaTime);
    }
}
