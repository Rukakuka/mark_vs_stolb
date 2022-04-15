using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNavigate : MonoBehaviour
{
    public static Transform cameraTransform;
    public static Vector2 cameraRotation;

    private float zoomSpeed;
    private float rotSpeed = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform;
        return;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (CameraChangeView.cameras[CameraChangeView.currentCameraIter].name == "FPVCamera")
                zoomSpeed = 300;
            else
                zoomSpeed = 3000;

            transform.localPosition += Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z) * new Vector3(1,0,0) * zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x ,
                                            transform.eulerAngles.y + Input.GetAxisRaw("Mouse X") * rotSpeed,
                                            transform.eulerAngles.z + Input.GetAxisRaw("Mouse Y") * rotSpeed);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                                            transform.eulerAngles.y,
                                            transform.eulerAngles.z);
        }

        return;
    }
}