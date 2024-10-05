using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingItemListSO cuttingItemList;
    [SerializeField] private ProgressBarUI progressBarUI;
    [SerializeField] private CuttingAnim cuttingAnim;

    private int cuttingCount;
    

    public override void Interact(Player player)
    {
        //玩家身上有食材
        if (player.IsHaveGranishItem())
        {
            //目标柜台上没有食材
            if (IsHaveGranishItem() == false)
            {
                cuttingCount = 0;
                TransferGarnishItem(player, this); //玩家身上的食材转移到柜台上
            }
            //目标柜台有食材
            else
            {
                // Debug.LogWarning("当前柜台已放满.");
            }
            
        }
        //玩家身上没有食材
        else
        {
            //目标柜台有食材
            if (IsHaveGranishItem() != false)
            {
                TransferGarnishItem(this, player); //柜台上的食材转移到玩家身上
                progressBarUI.Hide();
            }
            //目标柜台没有食材
            else
            {

            }
        }
    }

    public override void InteractOperate(Player player)
    {   
        if (IsHaveGranishItem()!= false)
        {

            if (cuttingItemList.TryGetCuttingItem(GetGarnishItem().GetGarnishSO(),out CuttingItem cuttingItem))
            {
                Cut();
                progressBarUI.UpdateProgress((float)cuttingCount / cuttingItem.cuttingCountMax);

                if (cuttingCount == cuttingItem.cuttingCountMax)
                {
                    DestroyGarnishItem();
                    CreatGarnishItem(cuttingItem.output.prefab);
                }
                
            }
            
        }
    }

    private void Cut()
    {
        cuttingCount++;
        cuttingAnim.PlayCut();
    }

}
