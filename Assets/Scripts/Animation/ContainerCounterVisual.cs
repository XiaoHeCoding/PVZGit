using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private Animator anim;
    
    private void Start() 
    {
        anim = GetComponent<Animator>();    
    }

    public void PlayOpen()
    {
        anim.SetTrigger("OpenClose");
    }

}
