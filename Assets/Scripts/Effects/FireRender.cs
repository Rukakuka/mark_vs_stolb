using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRender : MonoBehaviour
{
    public static ParticleSystem _particleSystem; 

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
