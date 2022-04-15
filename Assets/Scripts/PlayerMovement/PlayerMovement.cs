using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        rb.maxAngularVelocity = 1.2f;
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
    public void OnMouseAction()
    {
        Debug.Log("clicky");
    }

    public void OnControlsChanged()
    {
        Debug.Log("controlschanged");
    }
        public void OnMove()
    {

        float absVel = (float)(Sqrt(Pow(rb.velocity.x, 2) + Pow(rb.velocity.z, 2)));
        rb = GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.W))
        {
            if (absVel < maxVel)
                rb.AddRelativeForce(Vector3.right * trForce * Time.deltaTime, ForceMode.Impulse);

        }
        if (Input.GetKey(KeyCode.S))
        {
            if (absVel < maxVel)
            {
                float localForwardVelocity = Vector3.Dot(rb.velocity, rb.transform.forward);
                if (localForwardVelocity > 0)
                    rb.AddRelativeForce(Vector3.left * trForce * Time.deltaTime, ForceMode.Impulse);
                else
                    rb.AddRelativeForce(Vector3.left * trForce * Time.deltaTime, ForceMode.Impulse);
            }
        }

        if (absVel > 0.5)
        {
            if (Input.GetKey(KeyCode.A))
            {
                //rb.AddRelativeTorque(Vector3.up * -rotForce * Time.deltaTime * Abs(WheelRotationAnim.curRotation)/30f, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.D))
            {
                //rb.AddRelativeTorque(Vector3.up * rotForce * Time.deltaTime * WheelRotationAnim.curRotation/30f, ForceMode.Impulse);

            }
            rb.AddRelativeTorque(Vector3.up * rotForce * Time.deltaTime * -WheelRotationAnim.curRotation / 30f, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);

    }
}