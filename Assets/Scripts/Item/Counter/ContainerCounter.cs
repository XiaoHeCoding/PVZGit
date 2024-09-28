using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//仓库类柜台
public class ContainerCounter : BaseCounter
{
    [SerializeField] private Garnish_SO garnishSO;

    [SerializeField] private ContainerCounterVisual containerCounterVisual;
    
    
    public override void Interact(Player player)
    {
        if(player.IsHaveGranishItem()) return;

        CreatGarnishItem(garnishSO.prefab);
        TransferGarnishItem(this, player);

        containerCounterVisual.PlayOpen();
    }

    public void CreatGarnishItem(GameObject garnishItemPrefab)
    {
        GarnishItem garnishItem = GameObject.Instantiate(garnishItemPrefab, GetHoldPoint()).GetComponent<GarnishItem>();
        SetGarnishItem(garnishItem);
    }

}
