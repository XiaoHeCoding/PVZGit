using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : GarnishItemHolder
{
    [SerializeField] private GameObject selectedCounter;
    [SerializeField] private Garnish_SO garnishSO;
    [SerializeField] private ClearCounter transferTargetCounter;
    [SerializeField] private bool testing = false;


    private void Update() 
    {
        if (testing && Input.GetMouseButtonDown(0))
        {
            TransferGarnishItem(this, transferTargetCounter);
        }
    }

    public void Interact()
    {
        if (GetComponent<GarnishItem>() == null)
        {
            GarnishItem garnishItem = GameObject.Instantiate(garnishSO.prefab, GetHoldPoint()).GetComponent<GarnishItem>();
            SetGarnishItem(garnishItem);
        }
        else
        {
            Debug.LogWarning("已经有了-" + gameObject);
        }
    }

    public void SelectCounter()
    {
        selectedCounter.SetActive(true);
    }

    public void CancelSelect()
    {
        selectedCounter.SetActive(false);
    }


}
