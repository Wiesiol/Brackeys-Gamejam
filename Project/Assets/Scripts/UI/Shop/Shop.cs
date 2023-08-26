using Assets.Scripts.Gameplay;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        ShopTrigger.OnShopOpen.AddListener(EnterShop);
        PlayerStats.OnMoneyAmountUpdate.AddListener(UpdateMoney);
        exitButton.onClick.AddListener(ExitShop);
        moneyText.SetText(PlayerStats.Money.ToString());
    }

    private void OnDisable()
    {
        ShopTrigger.OnShopOpen.RemoveListener(EnterShop);
        PlayerStats.OnMoneyAmountUpdate.RemoveListener(UpdateMoney);
        exitButton.onClick.RemoveListener(ExitShop);
    }

    private void EnterShop()
    {
        GameSystems.gamestate = GameState.Shop;
        canvas.enabled = true;
        PlayerSystems.PlayerInventory.OpenInventory();
    }

    private void ExitShop()
    {
        canvas.enabled = false;
        PlayerSystems.PlayerInventory.CloseInventory();
        GameSystems.gamestate = GameState.Gameplay;
    }

    private void UpdateMoney()
    {
        moneyText.SetText(PlayerStats.Money.ToString());
        AbstractShopButton.OnButtonsForceRefresh.Invoke();
    }
}
