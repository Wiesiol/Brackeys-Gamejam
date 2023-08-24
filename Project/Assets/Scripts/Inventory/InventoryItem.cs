using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName ="ScriptableObject/Inventory/Item")]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField] public ItemInstance itemInstance;
        [field: SerializeField] public Sprite ItemSprite { get; private set; }

        public void SpawnItem(Vector3 position)
        {
            Instantiate(itemInstance, position, Quaternion.identity);
        }
    }
}