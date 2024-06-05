using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        public int width;
        public int height;

        public void Rotate()
        {
            int temp = width;
            width = height;
            height = temp;
        }
    }
}