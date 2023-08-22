using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int slots;
        [SerializeField] private List<InventoryItem> items;
        [SerializeField] private Transform dropTransform;
        [SerializeField] private GameObject slotPrefab;

        public static UnityEvent<InventoryItem> OnItemAdded = new();
        public static UnityEvent<int> OnSlotCleared = new();

        private void RemoveItem(int index)
        {
            if (items[index] != null)
            {
                items[index].SpawnItem(dropTransform.position);
                items.Remove(items[index]);
            }
        }

        private void AddItem(InventoryItem item)
        {
            if(items.Count < slots)
            {
                items.Add(item);
            }
        }
    }

    public class InventoryItem : ScriptableObject
    {
        [SerializeField] private ItemInstance itemInstance;
        [SerializeField] private Sprite ItemSprite;

        public void SpawnItem(Vector3 position)
        {
            Instantiate(itemInstance, position, Quaternion.identity);
        }
    }

    public class ItemInstance : MonoBehaviour
    {
        [SerializeField] private InventoryItem item;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Inventory.OnItemAdded.Invoke(item);
            }
        }
    }

    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image ItemImage;
        [SerializeField] private Button button;
        [SerializeField] private InventoryItem inventoryItem;

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
            }
        }

        public void PutItem(InventoryItem item)
        {
            inventoryItem = item;
        }
    }
}