using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int slots;
        //[SerializeField] private List<InventoryItem> items;
        [SerializeField] private Transform dropTransform;
        [SerializeField] private List<InventorySlot> inventorySlots = new();
        [SerializeField] private InventoryItem itemToAddInEditor;
        public GameObject inventoryHolder;

        public static UnityEvent<InventoryItem> OnItemAdded = new();
        public static UnityEvent<int> OnSlotCleared = new();


        private void OnEnable()
        {
            InputManager.Input.Inventory.CloseInventory.performed += CloseInventory;
            InputManager.Input.Gameplay.OpenInventory.performed += OpenInventory;
        }

        private void OnDisable()
        {
            InputManager.Input.Inventory.CloseInventory.performed -= CloseInventory;
            InputManager.Input.Gameplay.OpenInventory.performed -= OpenInventory;
        }

        private void OpenInventory(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            InputManager.ChangeActionMap(ActionMaps.Inventory);
            inventoryHolder.SetActive(true);
            ShowPropperSlotsCount();
        }

        private void CloseInventory(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            InputManager.ChangeActionMap(ActionMaps.Gameplay);
            inventoryHolder.SetActive(false);
        }

        [ContextMenu("Add Item")]
        public void AddItem()
        {
            AddItem(itemToAddInEditor);
        }

        private void AddItem(InventoryItem item)
        {
            var freeSlot = inventorySlots.FirstOrDefault(x => x.CanPutItemInside && x.gameObject.activeInHierarchy);

            if (freeSlot != null)
            {
                freeSlot.PutItem(item);
            }

            else
            {
                Debug.Log("Inventory Full");
            }
        }

        public void ShowPropperSlotsCount()
        {
            for (int i = 0; i < slots; i++)
            {
                inventorySlots[i].gameObject.SetActive(true);
            }
        }
    }
}