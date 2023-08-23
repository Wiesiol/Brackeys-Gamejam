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
                Inventory.OnSlotCleared.Invoke(transform.GetSiblingIndex());
                inventoryItem = null;
                ItemImage.enabled = false;
            }
        }

        public void PutItem(InventoryItem item)
        {
            inventoryItem = item;
            ItemImage.enabled = true;
            ItemImage.sprite = item.ItemSprite;
        }
    }
}