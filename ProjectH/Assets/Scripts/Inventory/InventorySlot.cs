namespace Inventory
{
    [System.Serializable]
    public class InventorySlot
    {
        private Item item;

        public void AddItem(Item newItem)
        {
            item = newItem;
        }

        public Item GetItem()
        {
            return item;
        }

        public bool IsEmpty()
        {
            return item == null;
        }

        public void RemoveItem()
        {
            item = null;
        }
    }
}