using Inventory;
using UnityEngine;

[DefaultExecutionOrder(int.MinValue)]
public class PlayerSystems : MonoBehaviour
{
    public static Transform PlayerTransform { get; private set; }
    public static GameObject Player { get; private set; }
    [SerializeField] private Transform gatherTransform;
    public static Transform GatherTransform;

    public static PlayerInventory PlayerInventory{ get; private set; }
    [SerializeField] private PlayerInventory playerInventory; 

    private void Awake()
    {
        Player = gameObject;
        PlayerTransform = transform;
        GatherTransform = gatherTransform;
        PlayerInventory = playerInventory;
    }
}
