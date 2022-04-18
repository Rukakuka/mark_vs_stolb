using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.Math;
public class PlayerMovement : MonoBehaviour
{
    public GameObject masterCube;
    static public Rigidbody rb;
    static public float jumpForce;
    static public float trForce;
    static public float rotForce;
    private float maxVel = 25;
    Vector2 wheelRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 2.2f;
    }
    void Start()
    {
        jumpForce = 6000f;
        trForce = 700f;
        rotForce = 700f;
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 1.2f;
    }
    public void Update()
    {
        OnMove();
    }
    public void OnMove()
    {
        float absVel = (float)(Sqrt(Pow(rb.velocity.x, 2) + Pow(rb.velocity.z, 2)));
        rb = GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (absVel < maxVel)
            {
                rb.AddRelativeForce(Vector3.right * trForce * Time.deltaTime, ForceMode.Impulse);
                rb.AddRelativeTorque(Vector3.up * rotForce * Time.deltaTime * -WheelRotationAnim.curRotation / 30f * 1f, ForceMode.Impulse);
            }
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (absVel < maxVel)
            {
                rb.AddRelativeForce(Vector3.left * trForce * Time.deltaTime, ForceMode.Impulse);
            }
        }

        if (absVel > 0.5)
        {
            rb.AddRelativeTorque(Vector3.up * rotForce * Time.deltaTime * -WheelRotationAnim.curRotation / 30f, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            
            float localForwardVelocity = Vector3.Dot(rb.velocity, rb.transform.right);
            float localSideVelocity = Vector3.Dot(rb.velocity, rb.transform.forward);
            //float localAngularVelocity = rb.angularVelocity.x
            rb.AddRelativeForce(10f * 100f * Time.deltaTime * new Vector3(-localForwardVelocity, 0f, -localSideVelocity));
            rb.AddRelativeTorque(Vector3.up * rotForce * Time.deltaTime * -WheelRotationAnim.curRotation / 30f * 0.1f, ForceMode.Impulse);
        }

    }
}