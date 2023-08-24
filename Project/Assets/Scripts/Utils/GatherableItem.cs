using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherableItem : MonoBehaviour, IGatherable
{
    [SerializeField] private float timeToGather;
    [SerializeField] private InventoryItem drop;

    public void Gather()
    {
        if (timeToGather > 0)
        {
            timeToGather -= Time.deltaTime;
        } 
        
        else
        {
            drop.SpawnItem(transform.position);
            Destroy(gameObject);
        }
    }
}
