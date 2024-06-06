using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class ItemUI : MonoBehaviour
    {
        public Image itemImage;
        // public Button removeButton;
        // public Button rotateButton;

        private Item item;
        private InventoryUI inventoryUI;
        private InventorySlot slot;

        private void Start()
        {
            // removeButton.onClick.AddListener(OnRemoveButton);
            // rotateButton.onClick.AddListener(OnRotateButton);
        }

        public void Initialize(Item item, InventorySlot slot, InventoryUI inventoryUI)
        {
            this.item = item;
            this.slot = slot;
            this.inventoryUI = inventoryUI;
            UpdateItemUI();
        }

        public void UpdateItemUI()
        {
            if (item != null)
            {
                itemImage.sprite = item.icon;
                itemImage.enabled = true;
                // removeButton.gameObject.SetActive(true);
                // rotateButton.gameObject.SetActive(true);
            }
            else
            {
                itemImage.enabled = false;
                // removeButton.gameObject.SetActive(false);
                // rotateButton.gameObject.SetActive(false);
            }
        }

        private void OnRemoveButton()
        {
            slot.RemoveItem();
            inventoryUI.UpdateUI();
            Destroy(gameObject); // UI öğesini kaldır
        }

        private void OnRotateButton()
        {
            item.Rotate();
            inventoryUI.UpdateUI();
        }
    }
}