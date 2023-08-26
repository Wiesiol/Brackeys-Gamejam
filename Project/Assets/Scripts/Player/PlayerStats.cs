using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class PlayerStats
{
    public static UnityEvent OnOxygenLevelUpdate = new();
    private static int oxygenUpdateLevel = 0;
    public static int OxygenUpdateLevel
    {
        get => oxygenUpdateLevel;
        set
        {
            oxygenUpdateLevel = value;
            OnOxygenLevelUpdate.Invoke();
        }
    }

    public static UnityEvent OnBackpackLevelUpdate = new();
    private static int backpackUpdateLevel = 0;
    public static int BackpackUpdateLevel
    {
        get => backpackUpdateLevel;
        set
        {
            backpackUpdateLevel = value;
            OnBackpackLevelUpdate.Invoke();
        }
    }

    public static UnityEvent OnSwimmingSpeedLevelUpdate = new();
    private static int swimmingSpeedUpdateLevel = 0;
    public static int SwimmingSpeedUpdateLevel
    {
        get => swimmingSpeedUpdateLevel;
        set
        {
            swimmingSpeedUpdateLevel = value;
            OnSwimmingSpeedLevelUpdate.Invoke();
        }
    }

    public static UnityEvent OnMiningSpeedLevelUpdate = new();
    private static int miningSpeedUpdateLevel = 0;
    public static int MiningSpeedUpdateLevel
    {
        get => miningSpeedUpdateLevel;
        set
        {
            miningSpeedUpdateLevel = value;
            OnMiningSpeedLevelUpdate.Invoke();
        }
    }

    public static UnityEvent OnMoneyAmountUpdate = new();
    private static int money = 30;
    public static int Money
    {
        get => money;
        set
        {
            money = value;
            OnMoneyAmountUpdate.Invoke();
        }
    }
}
