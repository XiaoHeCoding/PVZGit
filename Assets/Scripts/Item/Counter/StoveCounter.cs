using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingItemList_SO fryingItemList;
    [SerializeField] private FryingItemList_SO burningItemList;
    [SerializeField] private StoveAnim stoveAnim;
    [SerializeField] private ProgressBarUI progressBarUI;

    public enum StoveState
    {
        Idle,
        Frying,
        Burning
    }
    private FryingItem fryingItem;
    private float fryingTimer;
    private StoveState state = StoveState.Idle;

    public override void Interact(Player player)
    {
         //玩家身上有食材
        if (player.IsHaveGranishItem())
        {
            //目标柜台上没有食材
            if (IsHaveGranishItem() == false)
            {
                if(fryingItemList.TryGetFryingItem(player.GetGarnishItem().GetGarnishSO(), out FryingItem fryingItem))
                {
                    TransferGarnishItem(player, this); //玩家身上的食材转移到柜台上
                    StartFry(fryingItem);
                }
                else if(burningItemList.TryGetFryingItem(player.GetGarnishItem().GetGarnishSO(), out FryingItem burningItem))
                {
                    TransferGarnishItem(player, this); //玩家身上的食材转移到柜台上
                    StartBurning(burningItem);
                }
                else
                {

                }
                
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
                TurnToIdle();
                TransferGarnishItem(this, player); //柜台上的食材转移到玩家身上
                // stoveAnim.HideStoveEffect();
            }
            //目标柜台没有食材
            else
            {

            }
        }
    }

    private void Update() 
    {
        switch (state)
        {
            case StoveState.Idle:
                break;

            case StoveState.Frying:
                fryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(fryingTimer / fryingItem.fryingTime);

                if(fryingTimer >= fryingItem.fryingTime)
                {
                    DestroyGarnishItem();
                    CreatGarnishItem(fryingItem.output.prefab);

                    state = StoveState.Burning;
                    burningItemList.TryGetFryingItem(GetGarnishItem().GetGarnishSO(), out FryingItem newfryingItem);
                    StartBurning(newfryingItem);
                }
                break;

            case StoveState.Burning:
                fryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(fryingTimer / fryingItem.fryingTime);

                if(fryingTimer >= fryingItem.fryingTime)
                {
                    DestroyGarnishItem();
                    CreatGarnishItem(fryingItem.output.prefab);
                    TurnToIdle();
                }
                break;

            default:
                break;
        }
    }
    
    private void StartFry(FryingItem fryingItem)
    {
        fryingTimer = 0;
        this.fryingItem = fryingItem;
        state = StoveState.Frying;
        stoveAnim.ShowStoveEffect();
    }

    private void StartBurning(FryingItem fryingItem)
    {
        if (fryingItem == null)
        {
            Debug.LogWarning("无法获得Burning的食谱,无法进行");
            TurnToIdle();
            return;
        }

        stoveAnim.ShowStoveEffect();
        fryingTimer = 0;
        this.fryingItem = fryingItem;
        state = StoveState.Burning;
    }

    private void TurnToIdle()
    {
        progressBarUI.Hide();
        state = StoveState.Idle;
        stoveAnim.HideStoveEffect();
    }

}
