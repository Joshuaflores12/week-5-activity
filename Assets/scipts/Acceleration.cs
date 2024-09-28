using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private  float duration;
    [SerializeField] private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        timer = duration;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
}
