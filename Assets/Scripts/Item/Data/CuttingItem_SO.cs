using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class CuttingItem
{
    public Garnish_SO input;
    public Garnish_SO output;
    public int cuttingCountMax;
}

[CreateAssetMenu()]
public class CuttingItemListSO : ScriptableObject
{
    public List<CuttingItem> list;

    public Garnish_SO GetOutPut(Garnish_SO input)
    {
        foreach (CuttingItem item in list)
        {
            if (item.input == input)
            {
                return item.output;
            }
        }
        return null;
    }

    public bool TryGetCuttingItem(Garnish_SO input,out CuttingItem cuttingItem)
    {
        foreach (CuttingItem item in list)
        {
            if (item.input == input)
            {
                cuttingItem = item;
                return true;
            }
        }
        cuttingItem = null;
        return false;
    }

}
