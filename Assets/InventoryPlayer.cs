using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : Inventory
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Inventory") > 0)
        {
            if (onInventoryButtonCallback != null)
            {
                onInventoryButtonCallback.Invoke();
            }
        }
    }
}
