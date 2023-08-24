using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystems : MonoBehaviour
{
    public static Transform PlayerTransform { get; private set; }
    public static GameObject Player { get; private set; }
    [SerializeField] private Transform gatherTransform;
    public static Transform GatherTransform;

    private void Awake()
    {
        Player = gameObject;
        PlayerTransform = transform;
        GatherTransform = gatherTransform;
    }
}
