using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeView : MonoBehaviour
{
    public static GameObject[] cameras;
    public GameObject[] cameraViews = new GameObject[3];
    public static int currentCameraIter = 0;
    private bool locker = false;
    public void Start()
    {
        cameras = cameraViews;
        Update();
        return;
    }
    public void Update()
    {
        //Debug.Log("I am alive!");
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!locker)
            {
                if (cameraViews.Length != 0)
                {
                    locker = true;
                    foreach (GameObject cameraView in cameraViews) {
                        cameraView.SetActive(false);
                        AudioListener _listener = cameraView.GetComponent<AudioListener>();
                        if (_listener != null)
                            _listener.enabled = false;
                    }

                    CameraNavigate.cameraRotation.x = 0;
                    CameraNavigate.cameraRotation.y = 0;
                    cameraViews[currentCameraIter].SetActive(true);
                    GameObject cam = GameObject.Find(cameraViews[currentCameraIter].name);
                    AudioListener listener = cam.GetComponent<AudioListener>();
                    if (listener != null)
                        listener.enabled = true;

                    switch (cameraViews[currentCameraIter].name)
                    {
                        case "FPVCamera":
                            {
                                CameraNavigate.cameraTransform.localPosition = new Vector3(-0.094f,
                                                                                           0.259f,
                                                                                           -0.173f);

                                CameraNavigate.cameraTransform.eulerAngles = new Vector3(PlayerMovement.rb.rotation.eulerAngles.x,
                                                                                         PlayerMovement.rb.rotation.eulerAngles.y,
                                                                                         PlayerMovement.rb.rotation.eulerAngles.z);
                            }

                            break;
                        case "Standart camera":
                            {
                                CameraNavigate.cameraTransform.localPosition = new Vector3(-3.19f,
                                                                                           0.998f,
                                                                                           0);

                                CameraNavigate.cameraTransform.eulerAngles = new Vector3(PlayerMovement.rb.rotation.eulerAngles.x,
                                                                                         PlayerMovement.rb.rotation.eulerAngles.y,
                                                                                         PlayerMovement.rb.rotation.eulerAngles.z - 5);
                            }
                            break;
                        case "Main Camera":
                            {
                                CameraNavigate.cameraTransform.localPosition = new Vector3(-2.654f,
                                                                                           1.16f,
                                                                                           0f);

                                CameraNavigate.cameraTransform.eulerAngles = new Vector3(PlayerMovement.rb.rotation.eulerAngles.x,
                                                                                         PlayerMovement.rb.rotation.eulerAngles.y,
                                                                                         PlayerMovement.rb.rotation.eulerAngles.z - 5);
                            }
                            break;

                        default:
                            break;
                    }

                    currentCameraIter++;
                    currentCameraIter = ((currentCameraIter % 3) == 0) ? (currentCameraIter = 0) : (currentCameraIter);

                    locker = false;
                }
            }
        }
        return;
    }
}
