using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingAnim : MonoBehaviour
{
    private const string CUT = "Cut";
    private Animator anim;

    private void Start() 
    {
        anim = GetComponent<Animator>();
    }

    public void PlayCut()
    {
        anim.SetTrigger(CUT);
    }

}
