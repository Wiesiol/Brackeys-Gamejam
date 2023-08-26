using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    public static UnityEvent OnShopOpen = new();

    private void OnTriggerEnter(Collider other)
    {
        if (playerLayer.value == (playerLayer.value | (1 << other.gameObject.layer)))
        {
            OnShopOpen.Invoke();
        }
    }
}
