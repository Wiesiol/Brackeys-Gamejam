using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSpeedUpdateButton : AbstractShopButton
{
    protected override void Buy()
    {
        PlayerStats.MiningSpeedUpdateLevel++;
    }

    protected override int GetUpdateLevel()
    {
        return PlayerStats.MiningSpeedUpdateLevel;
    }
}
