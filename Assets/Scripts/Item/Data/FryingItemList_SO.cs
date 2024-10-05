using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FryingItem
{
    public Garnish_SO input;
    public Garnish_SO output;
    public float fryingTime;
}

[CreateAssetMenu()]
public class FryingItemList_SO : ScriptableObject
{
    public List<FryingItem> list;

    public bool TryGetFryingItem(Garnish_SO input,out FryingItem fryingItem)
    {
        foreach (FryingItem item in list)
        {
            if (item.input == input)
            {
                fryingItem = item;
                return true;
            }
        }
        fryingItem = null;
        return false;
    }
}



