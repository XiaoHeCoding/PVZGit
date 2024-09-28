using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//空柜台
public class ClearCounter : BaseCounter
{
    


    public override void Interact(Player player)
    {
        //玩家身上有食材
        if (player.IsHaveGranishItem())
        {
            //目标柜台上没有食材
            if (IsHaveGranishItem() == false)
            {
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
            }
            //目标柜台没有食材
            else
            {

            }
        }
    }

    


}
