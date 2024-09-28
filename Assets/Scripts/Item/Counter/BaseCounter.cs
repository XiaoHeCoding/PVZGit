using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//柜台类共用父对象
public class BaseCounter : GarnishItemHolder
{
    [SerializeField] private GameObject selectedCounter;


    public virtual void Interact(Player player)
    {
        Debug.LogWarning("交互方法没有重写.");
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
