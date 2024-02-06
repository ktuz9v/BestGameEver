using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Rigidbody body;

    public float elevatorSpeed;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 Forse = new Vector3(0,elevatorSpeed,0);
        body.AddForce(Forse * Time.deltaTime);
    }
}
