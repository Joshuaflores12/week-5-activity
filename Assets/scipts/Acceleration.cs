using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform target;
#pragma warning disable IDE0052 // Remove unread private members
    private Vector3 initialV;
#pragma warning restore IDE0052 // Remove unread private members
    private Vector3 targetV;
    [SerializeField] private float finalV, accelerationT, deceleration, decelerationFT, time;

#pragma warning disable IDE0051 // Remove unused private members
    void Start()
#pragma warning restore IDE0051 // Remove unused private members
    {
        rb = GetComponent<Rigidbody>();
        initialV = Vector3.zero;
    }

    // Update is called once per frame
#pragma warning disable IDE0051 // Remove unused private members
    void FixedUpdate()
    {
        CubeAcceleration();
    }
#pragma warning restore IDE0051 // Remove unused private members


    void CubeAcceleration()
    {
        Vector3 Dir = (target.position - transform.position).normalized;
        float targetDist = Vector3.Distance(transform.position, target.position);
        if (targetDist > deceleration)
        {
            targetV = Dir * finalV;
            time += Time.deltaTime / accelerationT;
        }
        else
        {
            decelerationFT = targetDist / deceleration;
            targetV = Dir * finalV * decelerationFT;
        }
        rb.velocity = Vector3.Lerp(rb.velocity, targetV, time);

        if (targetDist < 1.3f) 
        {
            rb.velocity = Vector3.zero;
        }
    }
}