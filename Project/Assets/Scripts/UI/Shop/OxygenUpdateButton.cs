using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenUpdateButton : AbstractShopButton
{
    protected override void Buy()
    {
        PlayerStats.oxygenUpdateLevel++;
    }

    protected override int GetUpdateLevel()
    {
        return PlayerStats.oxygenUpdateLevel;
    }
}
