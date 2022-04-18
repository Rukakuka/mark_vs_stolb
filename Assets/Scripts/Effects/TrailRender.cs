using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class TrailRender : MonoBehaviour
{
    static public int DriftScore = 0;
    private Rigidbody rb;
    private TrailRenderer[] trailRenderers;
    // Start is called before the first frame update
    void Start()
    {
        DriftScore = 0;
        rb = PlayerMovement.rb;
        trailRenderers = GetComponentsInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float localForwardVelocity = Abs(Vector3.Dot(rb.velocity, rb.transform.forward));
        float localSidewaysVelocity = Abs(Vector3.Dot(rb.velocity, rb.transform.right));

        if (localSidewaysVelocity * 0.3 > localForwardVelocity)
        {
            foreach (TrailRenderer tr in trailRenderers)
            {
                tr.emitting = false;
            }
        }
        else
        {
            if ((float)(Sqrt(Pow(PlayerMovement.rb.velocity.x, 2) + Pow(PlayerMovement.rb.velocity.z, 2))) > 0.5)
                    DriftScore +=1;
            
            foreach (TrailRenderer tr in trailRenderers)
            {
                tr.emitting = true;
            }
        }
    }
}
