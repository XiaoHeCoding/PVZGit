using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarnishItemHolder : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;


    private GarnishItem garnishItem;

    public Transform GetHoldPoint()
    {
        return holdPoint;
    }

    public bool IsHaveGranishItem()
    {
        return garnishItem != null;
    }

    public void SetGarnishItem(GarnishItem garnishItem)
    {
        this.garnishItem = garnishItem;
        garnishItem.transform.localPosition = Vector3.zero;
    }

    public GarnishItem GetGarnishItem()
    {
        return garnishItem;
    }

    public void TransferGarnishItem(GarnishItemHolder sourceHolder, GarnishItemHolder targetHolder)
    {
        if (sourceHolder.GetGarnishItem() == null)
        {
            Debug.LogWarning("原持有者不存在食材,转移失败。");
            return;
        }
        if (targetHolder.GetGarnishItem() != null)
        {
            Debug.LogWarning("目标持有者存在食材,转移失败。");
            return;
        }

        targetHolder.AddGarnishItem(sourceHolder.GetGarnishItem());
        sourceHolder.ClearGarnishItem();
    }

    public void AddGarnishItem(GarnishItem garnishItem)
    {
        garnishItem.transform.SetParent(holdPoint);
        garnishItem.transform.localPosition = Vector3.zero;
        this.garnishItem = garnishItem;
    }

    public void ClearGarnishItem()
    {
        this.garnishItem = null;
    }

}
