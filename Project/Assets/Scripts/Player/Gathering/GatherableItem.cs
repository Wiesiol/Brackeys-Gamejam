using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherableItem : MonoBehaviour, IGatherable
{
    [SerializeField] private float timeToGather;
    [SerializeField] private InventoryItem drop;
    private float playSoundInterval = 0;

    public void Gather()
    {
        if (timeToGather > 0)
        {
            timeToGather -= Time.deltaTime;
            playSoundInterval -= Time.deltaTime * (PlayerStats.MiningSpeedUpdateLevel + 1);

            if (playSoundInterval < 0)
            {
                playSoundInterval = 0.5f;
                SoundManager.Instance.PlayRandomSoundOfType(SoundType.destroyingBlock);
            }
        } 
        
        else
        {
            SoundManager.Instance.PlayStoneDestroyedSound();
            drop.SpawnItem(transform.position);
            Destroy(gameObject);
        }
    }
}
