using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafRenderer : MonoBehaviour
{
    public static Transform TreeTransform = null;
    public static Transform ParticleSystemTransform = null;
    public static ParticleSystem LeafParticleSystem = null;
    public static Rigidbody rb = null;
    // Start is called before the first frame update
    void Start()
    {

        LeafParticleSystem = GetComponentInChildren<ParticleSystem>();
        rb = GetComponentInChildren<Rigidbody>();
        TreeTransform = transform;
        ParticleSystemTransform = LeafParticleSystem.transform;
        LeafParticleSystem.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
