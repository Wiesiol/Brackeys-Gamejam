using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherableItem : MonoBehaviour
{
    [SerializeField] private float timeToGather;

    public void DestroyItem()
    {
        if (timeToGather > 0)
        {
            timeToGather -= Time.deltaTime;
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
