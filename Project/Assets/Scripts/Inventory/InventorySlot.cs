using Assets.Scripts.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image ItemImage;
        [SerializeField] private Button button;
        [SerializeField] private InventoryItem inventoryItem;
        public bool CanPutItemInside => inventoryItem == null;

        private void OnEnable()
        {
            button.onClick.AddListener(AbandonItem);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(AbandonItem);
        }

        public void AbandonItem()
        {
            if (inventoryItem != null)
            {
                if (GameSystems.gamestate == GameState.Shop)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Instance.SellItem);
                    inventoryItem.Sell();
                }

                else if (GameSystems.gamestate == GameState.Gameplay)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Instance.DiscardItem);
                    PlayerInventory.OnSlotCleared.Invoke(inventoryItem);
                }

                inventoryItem = null;
                ItemImage.gameObject.SetActive(false);
            }
        }

        public void PutItem(InventoryItem item)
        {
            inventoryItem = item;
            ItemImage.gameObject.SetActive(true);
            ItemImage.sprite = item.ItemSprite;
        }
    }
}