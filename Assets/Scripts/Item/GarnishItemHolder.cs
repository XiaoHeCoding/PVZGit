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

    public void SetGarnishItem(GarnishItem garnishItem)
    {
        this.garnishItem = garnishItem;
        garnishItem.transform.localPosition = Vector3.zero;
    }

    public GarnishItem GetGarnishItem()
    {
        return garnishItem;
    }

    public void TransferGarnishItem(ClearCounter sourceCounter, ClearCounter targetCounter)
    {
        if (sourceCounter.GetGarnishItem() == null)
        {
            Debug.LogWarning("原柜台不存在食材,转移失败。");
            return;
        }
        if (targetCounter.GetGarnishItem() != null)
        {
            Debug.LogWarning("目标柜台存在食材,转移失败。");
            return;
        }

        targetCounter.AddGarnishItem(sourceCounter.GetGarnishItem());
        sourceCounter.ClearGarnishItem();
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
