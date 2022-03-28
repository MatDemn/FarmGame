using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMechanics : MonoBehaviour
{
    CraftingSlot[] craftingArray;
    // Start is called before the first frame update
    void Start()
    {
        craftingArray = new CraftingSlot[2];
        craftingArray[0] = transform.GetChild(0).GetComponentInChildren<CraftingSlot>();
        craftingArray[1] = transform.GetChild(2).GetComponentInChildren<CraftingSlot>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
