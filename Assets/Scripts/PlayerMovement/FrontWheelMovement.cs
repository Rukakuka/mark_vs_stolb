using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWheelMovement : MonoBehaviour
{
    public float velocity = 4f;
    public float anglularVelocity = 50f;

    public GameObject wheel;
    public Rigidbody rb;
    float engineTorque = 2e-0f;

    Vector3 m_EulerAngleVelocity;
    Vector2 wheelRotation;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 0.8f;
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {

                rb.AddRelativeTorque(Vector3.forward * -engineTorque, ForceMode.Impulse);

        }
        if (Input.GetKey(KeyCode.A))
        {
               rb.AddRelativeTorque(Vector3.forward * engineTorque, ForceMode.Impulse);
        }
    }
}
