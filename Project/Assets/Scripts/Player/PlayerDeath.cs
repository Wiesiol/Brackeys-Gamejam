using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerDeath
{

    public static void KillPlayer()
    {
        PlayerSystems.Player.transform.position = Vector3.zero;
        PlayerSystems.PlayerInventory.EmptyInventory();
        PlayerSystems.OxygenMenager.SetMaxOxygen();
    }
}
