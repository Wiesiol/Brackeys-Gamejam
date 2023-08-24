using UnityEngine;

namespace Inventory
{
    public class ItemInstance : MonoBehaviour
    {
        [SerializeField] private InventoryItem item;

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        //    {
        //        Inventory.OnItemAdded.Invoke(item);
        //    }
        //}
    }
}