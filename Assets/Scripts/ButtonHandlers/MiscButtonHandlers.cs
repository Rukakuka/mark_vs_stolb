using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscButtonHandlers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Restart");
            GameOverScript.Restart();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}
