using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveAnim : MonoBehaviour
{
    [SerializeField] private GameObject stoveOnVisual;
    [SerializeField] private GameObject sizzlingParticles;

    public void ShowStoveEffect()
    {
        stoveOnVisual.SetActive(true);
        sizzlingParticles.SetActive(true);
    }

    public void HideStoveEffect()
    {
        stoveOnVisual.SetActive(false);
        sizzlingParticles.SetActive(false);
    }

    

}
