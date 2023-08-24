using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUpdateButton : AbstractShopButton
{
    protected override void Buy()
    {
        PlayerStats.backpackUpdateLevel++;
    }

    protected override int GetUpdateLevel()
    {
        return PlayerStats.backpackUpdateLevel;
    }
}
