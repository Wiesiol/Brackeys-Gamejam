using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class PlayerDeath
{
    public static UnityEvent OnPlayerDeath = new();

    public static void KillPlayer()
    {
        OnPlayerDeath.Invoke();
        PlayerSystems.PlayerInventory.EmptyInventory();
        PlayerSystems.Player.transform.position = new Vector3(-22.0599995f, -1.80999994f, -17.3199997f);
        PlayerSystems.OxygenMenager.SetMaxOxygen();
        SoundManager.Instance.PlaySound(SoundManager.Instance.Die);
    }
}
