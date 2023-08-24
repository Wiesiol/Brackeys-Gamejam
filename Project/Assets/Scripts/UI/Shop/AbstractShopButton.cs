using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class AbstractShopButton : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private int maxUpdateLevel;
    [SerializeField] private TextMeshProUGUI costText;
    private Button button;
    static UnityEvent OnButtonsForceRefresh = new();

    private void Awake()
    {
        button = GetComponent<Button>();
        UpdateButton();
    }

    private bool CanAfford()
    {
        return PlayerStats.money >= cost;
    }

    private bool CanUpgrade()
    {
        return GetUpdateLevel() < maxUpdateLevel;
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
        OnButtonsForceRefresh.AddListener(UpdateButton);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
        OnButtonsForceRefresh.RemoveListener(UpdateButton);
    }

    private void OnClick()
    {
        PlayerStats.money -= cost;
        Buy();
        OnButtonsForceRefresh.Invoke();
        Debug.Log(PlayerStats.money);
    }

    private void UpdateButton()
    {
        button.interactable = CanAfford() && CanUpgrade();
        costText.color = CanAfford() && CanUpgrade() ? Color.green : Color.red;
        costText.SetText(CanUpgrade() ? cost.ToString() : "SOLD OUT");
    }

    protected abstract void Buy();

    protected abstract int GetUpdateLevel();
}
