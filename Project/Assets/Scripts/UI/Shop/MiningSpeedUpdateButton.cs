using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSpeedUpdateButton : AbstractShopButton
{
    protected override void Buy()
    {
        PlayerStats.miningSpeedUpdateLevel++;
    }

    protected override int GetUpdateLevel()
    {
        return PlayerStats.miningSpeedUpdateLevel;
    }
}
