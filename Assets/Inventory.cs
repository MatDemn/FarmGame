using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    public Action<List<int>> onItemAddedCallback;

    public Action<List<int>> onItemDeletedCallback;

    public Action<List<int>> onItemUpdatedCallback;

    public Action onInventoryButtonCallback;

    public InventoryArray inventoryArray;

    public Item debugItemRef;

    [SerializeField]
    int inventorySize;
    
    void Awake()
    {
        inventoryArray = new InventoryArray(inventorySize);
        StartCoroutine("debugAddToInventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator debugAddToInventory() {
        Debug.LogWarning("Debug needs to be removed...");
        yield return new WaitForSeconds(1);
        if (gameObject.name == "Player")
        {
            Add(new InvSlotItem(debugItemRef, 3));
            Add(new InvSlotItem(debugItemRef, 1));
        }
    }

    public InvSlotItem this[int i]
    {
        get => inventoryArray[i];
    }

    public bool Add(InvSlotItem invSlotItem) {
        List<int> indexes = inventoryArray.Add(invSlotItem);
        if(indexes.Count > 0) {
            if(onItemAddedCallback != null)
                onItemAddedCallback.Invoke(indexes);
            return true;
        }
        return false;
    }

    public static bool Transfer(Inventory inv1, Inventory inv2, int indexFrom, int indexTo)
    {
        if(InventoryArray.Transfer(inv1, inv2, indexFrom, indexTo))
        {
            inv1.onItemUpdatedCallback?.Invoke(new List<int>() { indexFrom });
            inv2.onItemUpdatedCallback?.Invoke(new List<int>() { indexTo });
            return true;
        }
        else
        {
            Debug.LogWarning("Transfer between inventories false for some reason...");
            return false;
        }
    }

    public bool Remove(int index) {
        bool itemRemoved = inventoryArray.Remove(index);
        if(itemRemoved) {
            if(onItemDeletedCallback != null)
                onItemDeletedCallback.Invoke(new List<int>() { index });
            return true;
        }
        return false;
    }
    
}
