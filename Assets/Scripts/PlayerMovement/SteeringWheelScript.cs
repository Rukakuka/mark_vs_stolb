using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rot = WheelRotationAnim.curRotation * 10;
        transform.localRotation = Quaternion.Euler(rot, 0, 0);
    }
}
