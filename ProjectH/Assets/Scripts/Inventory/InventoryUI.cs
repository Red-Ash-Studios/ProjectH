using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        public GameObject slotPrefab;
        public GameObject itemUIPrefab;
        public Transform slotsParent;

        private InventorySystem inventorySystem;
        private List<InventorySlotUI> slotUIs = new List<InventorySlotUI>();

        private void Start()
        {
            inventorySystem = FindObjectOfType<InventorySystem>();
            CreateSlots();
        }

        private void CreateSlots()
        {
            for (int i = 0; i < inventorySystem.slots.Length; i++)
            {
                GameObject slotObj = Instantiate(slotPrefab, slotsParent);
                InventorySlotUI slotUI = slotObj.GetComponent<InventorySlotUI>();
                slotUI.SetSlot(inventorySystem.slots[i]);
                slotUIs.Add(slotUI);
            }
        }

        public void UpdateUI()
        {
            foreach (var slotUI in slotUIs)
            {
                slotUI.UpdateUI();
            }
        }
    }
}