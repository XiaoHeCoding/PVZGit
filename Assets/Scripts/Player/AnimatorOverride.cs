using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOverride : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private Animator anim;
    [SerializeField] private Player player;

    private void Start() 
    {
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        anim.SetBool(IS_WALKING, player.IsWalking);
    }

}
