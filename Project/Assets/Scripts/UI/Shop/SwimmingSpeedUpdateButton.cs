using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingSpeedUpdateButton : AbstractShopButton
{
    protected override void Buy()
    {
        PlayerStats.swimmingSpeedUpdateLevel++;
    }

    protected override int GetUpdateLevel()
    {
        return PlayerStats.swimmingSpeedUpdateLevel;
    }
}
