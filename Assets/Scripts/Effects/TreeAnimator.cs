using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimator : MonoBehaviour
{
    public static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("treeIdleAnim"))
        {
            anim.SetBool("treeRespawned", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("treeDestroyed"))
        {
            LeafRenderer.ParticleSystemTransform.eulerAngles = new Vector3(-90, 0, 0);
            if (!LeafRenderer.LeafParticleSystem.isEmitting)
                LeafRenderer.LeafParticleSystem.Play();
            anim.SetBool("treeHit", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("treeNoneAnimation"))
        {
            LeafRenderer.rb.velocity = new Vector3(0, 0, 0);
            LeafRenderer.rb.angularVelocity = new Vector3(0, 0, 0);
            LeafRenderer.TreeTransform.localEulerAngles = new Vector3(0, 0, 0);
            LeafRenderer.TreeTransform.eulerAngles = new Vector3(0, 0, 0);
            LeafRenderer.TreeTransform.localScale = new Vector3(0, 0, 0);
            anim.SetBool("treeRespawned", true);
        }        
    }
}
