using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    [SerializeField] private float spawnRate = 3;
    [SerializeField] private Garnish_SO plateSO;
    [SerializeField] private int plateCountMax = 5;

    private float timer = 0;
    private List<GarnishItem> platesList = new List<GarnishItem>();
    
    
    private void Update() 
    {
        if (platesList.Count < plateCountMax)
        {
            timer += Time.deltaTime;
        }
        
        if (timer > spawnRate)
        {
            timer = 0;
            SpawnPlate();
            
        }
    }

    public override void Interact(Player player)
    {
        //玩家身上没食材
        if (player.IsHaveGranishItem() == false)
        {
            if (platesList.Count > 0)
            {
                player.AddGarnishItem(platesList[platesList.Count - 1]);
                platesList.RemoveAt(platesList.Count - 1);
            }
        }
    }

    public void SpawnPlate()
    {
        if (platesList.Count >= plateCountMax) 
        {
            timer = 0;
            return;
        }
        

        GarnishItem garnishItem = GameObject.Instantiate(plateSO.prefab, GetHoldPoint()).GetComponent<GarnishItem>();

        garnishItem.transform.localPosition = Vector3.zero + Vector3.up * 0.1f * platesList.Count;
        platesList.Add(garnishItem);
    }

}
