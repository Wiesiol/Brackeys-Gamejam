using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI oxygenLevelText;

    void Start()
    {
        
    }

    void Update()
    {
        oxygenLevelText.SetText(((int)PlayerSystems.OxygenMenager.oxygenLevel).ToString());
    }
}
