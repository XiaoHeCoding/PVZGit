using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarnishItem : MonoBehaviour
{
    [SerializeField] private Garnish_SO garnishSO;

    public Garnish_SO GetGarnishSO()
    {
        return garnishSO;
    }

}
