using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearWheelMovement : MonoBehaviour
{
    public float velocity = 4f;
    public float anglularVelocity = 50f;

    public GameObject wheel;
    public Rigidbody rb;
    float engineTorque = 1f;

    Vector2 wheelRotation;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 50;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeTorque(Vector3.up * engineTorque, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeTorque(Vector3.down * engineTorque, ForceMode.Impulse);
        }
    }
}
