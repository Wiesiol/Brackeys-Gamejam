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
            button.onClick.AddListener(DropItem);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(DropItem);
        }

        private void DropItem()
        {
            if (inventoryItem != null)
            {
                if (GameSystems.gamestate == GameState.Shop)
                {
                    inventoryItem.Sell();
                }

                else if (GameSystems.gamestate == GameState.Gameplay)
                {
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