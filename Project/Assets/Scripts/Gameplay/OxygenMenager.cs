using Assets.Scripts.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenMenager : MonoBehaviour
{
    public float oxygenLevel;
    private const int maxOxygenLevelBase = 120;
    private const int maxOxygenLevelUpdated = 300;

    private void OnEnable()
    {
        PlayerStats.OnOxygenLevelUpdate.AddListener(SetMaxOxygen);
    }

    private void OnDisable()
    {
        PlayerStats.OnOxygenLevelUpdate.RemoveListener(SetMaxOxygen);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetMaxOxygen();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSystems.gamestate == GameState.Gameplay)
        {
            oxygenLevel -= Time.deltaTime;
        } else
        {
            SetMaxOxygen();
        }
        if (oxygenLevel <= 0)
        {
            PlayerDeath.KillPlayer();
        }
    }

    public void SetMaxOxygen()
    {
        oxygenLevel = PlayerStats.OxygenUpdateLevel == 0 ? maxOxygenLevelBase : maxOxygenLevelUpdated;
    }
}
