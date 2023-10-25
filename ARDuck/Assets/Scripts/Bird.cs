using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [Range(0, 10)]
    public float speedAnimation;

    [Header("Target")]
    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    public float minZ;
    public float maxZ;

    [Header("Position")]
    public Vector3 velocity;
    public float speed;
    public float smoothTime;

    [Header("Rotation")]
    public float speedRotation;
    private Quaternion rotGoal;
    private Vector3 direction;

    private Vector3 target;
    private float distance;

    private BirdSpawner birdSpawner;
    private Rigidbody rb;
    private bool isLiving = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        birdSpawner = GameObject.FindGameObjectWithTag("BirdSpawner").GetComponent<BirdSpawner>();
        GetTarget();
    }
    void Update()
    {
        if (isLiving)
        {
            animator.speed = speedAnimation;
            CheckPosition();
            CheckRotation();
        }
    }

    private void GetTarget()
    {
        target = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
    }

    private void CheckPosition()
    {
        distance = Vector3.Distance(transform.position, target);

        if(distance >= 0.01)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime, speed);
        }
        else
        {
            GetTarget();
        }
    }

    private void CheckRotation() 
    {
        direction = (target - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, speedRotation * Time.deltaTime);
    }

    public void DieBird()
    {
        isLiving = false;
        animator.speed = 0;
        rb.isKinematic = false;
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isLiving)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        birdSpawner.RemoveInList(gameObject);
    }
}
