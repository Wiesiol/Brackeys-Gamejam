using UnityEngine;

namespace Inventory
{
    public class ItemInstance : MonoBehaviour, IGatherable
    {
        [SerializeField] private InventoryItem item;

        public void Gather()
        {
            Inventory.OnItemAdded.Invoke(item);
            Destroy(gameObject);
        }
    }
}