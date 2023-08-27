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
    [SerializeField] private String title;
    private Button button;
    public static UnityEvent OnButtonsForceRefresh = new();

    private void Awake()
    {
        button = GetComponent<Button>();
        UpdateButton();
    }

    private bool CanAfford()
    {
        return PlayerStats.Money >= cost;
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
        PlayerStats.Money -= cost;
        Buy();
        SoundManager.Instance.PlaySound(SoundManager.Instance.SellItem);
        OnButtonsForceRefresh.Invoke();
    }

    private void UpdateButton()
    {
        button.interactable = CanAfford() && CanUpgrade();
        costText.color = CanAfford() && CanUpgrade() ? Color.green : Color.red;
        costText.SetText(title + System.Environment.NewLine + (CanUpgrade() ? cost.ToString() : "SOLD OUT"));
    }

    protected abstract void Buy();

    protected abstract int GetUpdateLevel();
}
