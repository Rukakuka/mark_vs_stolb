using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOffScript : MonoBehaviour
{
    private Light[] _lights;
    public static Light[] lights;

    // Start is called before the first frame update
    void Start()
    {
        _lights = new Light[4];
        GameObject gameObject;
        gameObject  = GameObject.Find("FLR");
        _lights[0] = gameObject.GetComponent<Light>();
        gameObject = GameObject.Find("FLL");
        _lights[1] = gameObject.GetComponent<Light>();
        gameObject = GameObject.Find("RLR");
        _lights[2] = gameObject.GetComponent<Light>();
        gameObject = GameObject.Find("RLL");
        _lights[3] = gameObject.GetComponent<Light>();

        foreach (Light light in _lights)
            light.enabled = true;

        lights = _lights;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
