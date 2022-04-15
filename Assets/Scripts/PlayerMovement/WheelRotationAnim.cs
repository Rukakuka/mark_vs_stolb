using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class WheelRotationAnim : MonoBehaviour
{
    public GameObject wheelRight;
    public GameObject wheelLeft;
    public GameObject wheelRightRear;
    public GameObject wheelLeftRear;
    public GameObject wheelRightRotAxis;
    public GameObject wheelLeftRotAxis;

    public Rigidbody rb;
    Vector3 wheelRotation;

    static public float curRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        wheelRight = GameObject.Find("FWR_Rotator");
        wheelLeft = GameObject.Find("FWL_Rotator");

        wheelRightRotAxis = GameObject.Find("FWR_rb");
        wheelLeftRotAxis = GameObject.Find("FWL_rb");

        wheelRightRear = GameObject.Find("RWR_Rotator");
        wheelLeftRear = GameObject.Find("RWL_Rotator");

    }

    void Update()
    {
        curRotation += 0.03f * -Sign(curRotation) * Time.deltaTime * 500;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (curRotation > -30f)
            {
                curRotation -= 0.1f * Time.deltaTime * 500;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (curRotation < 30f)
            {
                curRotation += 0.1f * Time.deltaTime * 500;
            }
        }

        wheelRightRotAxis.transform.localRotation = Quaternion.Euler(90f, 0f, curRotation);
        wheelLeftRotAxis.transform.localRotation = Quaternion.Euler(90f, 0f, curRotation);

        float localForwardVelocity = Vector3.Dot(PlayerMovement.rb.velocity, PlayerMovement.rb.transform.right);

        //wheelRotation.z += (float)(Sqrt(Pow(PlayerMovement.rb.velocity.x, 2) +
        //                               Pow(PlayerMovement.rb.velocity.y, 2)) * Time.deltaTime * -100);
        wheelRotation.z += localForwardVelocity * Time.deltaTime * -100;

        wheelRight.transform.localRotation = Quaternion.Euler(0f, wheelRotation.z, 0);
        wheelLeft.transform.localRotation = Quaternion.Euler(0f, wheelRotation.z, 0);
        wheelRightRear.transform.localRotation = Quaternion.Euler(0f, wheelRotation.z, 0);
        wheelLeftRear.transform.localRotation = Quaternion.Euler(0f, wheelRotation.z, 0);
    }
}
