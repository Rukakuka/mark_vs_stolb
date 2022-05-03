using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimator : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreScript.Score >= 1)
        {
            anim.SetBool("isHit", true);
        }
        else
        {
            anim.SetBool("isHit", false);
        }
    }
}
