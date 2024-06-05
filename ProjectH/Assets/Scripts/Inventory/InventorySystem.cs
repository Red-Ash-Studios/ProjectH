using UnityEngine;

namespace Inventory
{
    public class InventorySystem : MonoBehaviour
    {
        public InventorySlot[] slots;

        private void Awake()
        {
            slots = new InventorySlot[20]; // Örneğin, 20 slot oluştur
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = new InventorySlot();
            }
        }

        public bool AddItem(Item item)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].IsEmpty())
                {
                    slots[i].AddItem(item);
                    return true;
                }
            }
            return false;
        }
    }
}