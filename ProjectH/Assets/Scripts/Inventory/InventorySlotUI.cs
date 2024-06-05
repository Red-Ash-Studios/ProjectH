using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventorySlotUI : MonoBehaviour
    {
        public Image icon;
        public GameObject itemUIPrefab;

        private InventorySlot slot;

        public void SetSlot(InventorySlot slot)
        {
            this.slot = slot;
            UpdateUI();
        }

        public void UpdateUI()
        {
            // // Önceki item UI'larını temizle
            // foreach (Transform child in transform)
            // {
            //     Destroy(child.gameObject);
            // }

            if (!slot.IsEmpty())
            {
                GameObject itemUIObj = Instantiate(itemUIPrefab, transform);
                ItemUI itemUI = itemUIObj.GetComponent<ItemUI>();
                itemUI.Initialize(slot.GetItem(), slot, FindObjectOfType<InventoryUI>());
            }
            // else
            // {
            //     icon.enabled = false; // Icon'u gizleyin eğer slot boşsa
            // }
        }
    }
}