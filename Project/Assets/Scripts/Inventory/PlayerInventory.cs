using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Inventory
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private int slots;
        //[SerializeField] private List<InventoryItem> items;
        [SerializeField] private Transform dropTransform;
        [SerializeField] private List<InventorySlot> inventorySlots = new();
        [SerializeField] private InventoryItem itemToAddInEditor;
        public GameObject inventoryHolder;

        public static UnityEvent<InventoryItem> OnItemAdded = new();
        public static UnityEvent<InventoryItem> OnSlotCleared = new();


        private void OnEnable()
        {
            InputManager.Input.Inventory.CloseInventory.performed += CloseInventory;
            InputManager.Input.Gameplay.OpenInventory.performed += OpenInventory;
            OnItemAdded.AddListener(AddItem);
            OnSlotCleared.AddListener(SpawnItem);
        }

        private void OnDisable()
        {
            InputManager.Input.Inventory.CloseInventory.performed -= CloseInventory;
            InputManager.Input.Gameplay.OpenInventory.performed -= OpenInventory;
            OnItemAdded.RemoveListener(AddItem);
            OnSlotCleared.RemoveListener(SpawnItem);
        }

        private void SpawnItem(InventoryItem item)
        {
            item.SpawnItem(dropTransform.position);
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
            var freeSlot = inventorySlots.FirstOrDefault(x => x.CanPutItemInside && x.transform.GetSiblingIndex() < slots);

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

        [ContextMenu("xD")]
        public bool IsInventoryFull()
        {
            var freeSlots = inventorySlots.Where(x => x.CanPutItemInside && x.transform.GetSiblingIndex() < slots).Count();
            //Debug.Log(freeSlots);
            return freeSlots == 0;
        }
    }
}