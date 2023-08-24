using UnityEngine;

namespace Inventory
{
    public class ItemInstance : MonoBehaviour, IGatherable
    {
        [SerializeField] private InventoryItem item;
        private static float minDistance = 0.7f;
        private static float speed = 0.8f;

        public void Gather()
        {
            float distance = Vector3.Distance(PlayerSystems.PlayerTransform.position, transform.position);
            if (distance < minDistance)
            {
                Inventory.OnItemAdded.Invoke(item);
                Destroy(gameObject);
            } else
            {
                Vector3 directionToTarget = PlayerSystems.GatherTransform.position - transform.position;
                Vector3 directionToTargetNormalized = directionToTarget.normalized;
                Vector3 moveVector = directionToTargetNormalized * speed * Time.deltaTime;
                transform.position += moveVector;
            }
        }
    }
}