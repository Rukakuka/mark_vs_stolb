using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using UnityEngine.UI;
using TMPro;

public class SpeedometerUpdate : MonoBehaviour
{
    private Rigidbody rb;
    public TextMeshProUGUI SpeedometerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb = PlayerMovement.rb;
        float absVelkmh = (float)(Sqrt(Pow(rb.velocity.x, 2) + Pow(rb.velocity.z, 2)))*3.6f;
        SpeedometerText.text = absVelkmh.ToString("000") + " km/h";
    }
}
