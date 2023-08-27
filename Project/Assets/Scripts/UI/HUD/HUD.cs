using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI oxygenLevelText;
    [SerializeField] private Image fadeOutPanel;

    private void OnEnable()
    {
        PlayerDeath.OnPlayerDeath.AddListener(FadeOut);
    }

    private void OnDisable()
    {
        PlayerDeath.OnPlayerDeath.RemoveListener(FadeOut);
    }

    void Start()
    {
        
    }

    void Update()
    {
        oxygenLevelText.SetText(((int)PlayerSystems.OxygenMenager.oxygenLevel).ToString());
    }

    private void FadeOut()
    {
        fadeOutPanel.DOFade(255f, 0.5f);
        fadeOutPanel.DOFade(0f, 0.5f);
    }
}
