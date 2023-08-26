using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUpdateButton : AbstractShopButton
{
    protected override void Buy()
    {
        PlayerStats.BackpackUpdateLevel++;
    }

    protected override int GetUpdateLevel()
    {
        return PlayerStats.BackpackUpdateLevel;
    }
}
