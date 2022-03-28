using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    public Action<List<int>> onItemAddedCallback;

    public Action onItemDeletedCallback;

    public Action<List<int>> onItemUpdatedCallback;

    public Action onInventoryButtonCallback;

    public InventoryArray inventoryArray;

    [SerializeField]
    int inventorySize;
    
    void Awake()
    {
        inventoryArray = new InventoryArray(inventorySize);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public static void Transfer(Inventory inv1, Inventory inv2, int indexFrom, int indexTo)
    {
        if(InventoryArray.Transfer(inv1, inv2, indexFrom, indexTo))
        {
            inv1.onItemUpdatedCallback?.Invoke(new List<int>() { indexFrom });
            inv2.onItemUpdatedCallback?.Invoke(new List<int>() { indexTo });
        }
        else
        {
            Debug.LogWarning("Transfer between inventories false for some reason...");
        }
    }

    public bool Remove(int index) {
        bool itemRemoved = inventoryArray.Remove(index);
        if(itemRemoved) {
            if(onItemDeletedCallback != null)
                onItemDeletedCallback.Invoke();
            return true;
        }
        return false;
    }
    
}
