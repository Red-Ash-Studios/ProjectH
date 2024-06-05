using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public Item currentItem;

        private InventorySystem inventorySystem;
        private InventoryUI inventoryUI;

        private void Start()
        {
            inventorySystem = FindObjectOfType<InventorySystem>();
            inventoryUI = FindObjectOfType<InventoryUI>();
            AddItemToInventory();
        }

        private void AddItemToInventory()
        {
            if (inventorySystem.AddItem(currentItem))
            {
                inventoryUI.UpdateUI();
            }
        }
    }
}