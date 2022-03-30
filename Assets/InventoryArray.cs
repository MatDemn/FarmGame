 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryArray
{
    [SerializeField]
    // From up to down, from left to right. First valid place for new item
    private int firstFreePlace_;

    [SerializeField]
    private InvSlotItem[] inventoryArray_;

    public InvSlotItem this[int i]{
        get {
            if(i < 0 || i >= Length) {
                Debug.LogError($"IndexOutOfBounds: {i}");
            }
            return inventoryArray_[i];
        }
    }

    private int freeCapacity_;

    public int Length
    {
        get => inventoryArray_.Length;
    }

    // Start is called before the first frame update
    public InventoryArray(int size) {
        if(size < 1) {
            throw new System.Exception("Wrong size of InventoryArray. Need to be >0");
        }
        firstFreePlace_ = 0;
        initInventory(size);
        freeCapacity_ = Length;
    }

    void initInventory(int size) {
        inventoryArray_ = new InvSlotItem[size];
        for(int i=0; i<inventoryArray_.Length; i++) {
            inventoryArray_[i] = new InvSlotItem(null, 0);
        }
    }

    public List<int> Add(InvSlotItem itemSlotToAdd) {
        List<int> result = new List<int>();
        // Check if this item is in inventory already?
        int leftoverQuantity = itemSlotToAdd.quantity;
        for(int i = 0; i<inventoryArray_.Length; i++)
        {
            // If this item is in inventory already (names are the same)
            if(inventoryArray_[i] != null && inventoryArray_[i].Name == itemSlotToAdd.Name) {
                // Check if you can add quantity to it
                int freeQuantity = inventoryArray_[i].FreeQuantity;
                if(freeQuantity >= itemSlotToAdd.quantity) {
                    inventoryArray_[i].quantity += itemSlotToAdd.quantity;
                    result.Add(i);
                    return result;
                }
                inventoryArray_[i].quantity += freeQuantity;
                result.Add(i);
                itemSlotToAdd.quantity -= freeQuantity;
            }
        }

        // If it's not in inventory or
        // it is, but all stacks are full
        // search for first free space for new item
        if(freeCapacity_ == 0)
            return result;
        if(inventoryArray_[firstFreePlace_].item != null) {
            Debug.LogWarning("There is some item in place of firstFreePlace. Check it out immadiatelly!");
            return result;
        }
        result.Add(firstFreePlace_);
        inventoryArray_[firstFreePlace_] = itemSlotToAdd;
        freeCapacity_ -= 1;
        UpdateFirstFreeSpace(this);
        return result;
    }

    public bool Transfer(int index, int toIndex) {
       
        int leftoverQuantity = inventoryArray_[index].quantity;
       
        // Something is here...
        if(inventoryArray_[toIndex].item != null) {
            if(inventoryArray_[toIndex].Name == inventoryArray_[index].Name) {
                // Merge item with existing (as much quantity as you can)
                int freeQuantity = inventoryArray_[toIndex].FreeQuantity;
                if(freeQuantity >= inventoryArray_[index].quantity) {
                    // That means we can merge everything without problems
                    inventoryArray_[toIndex].quantity += inventoryArray_[index].quantity;
                    inventoryArray_[index].ClearSlot();
                    return true;
                }
                else {
                    // Some leftover is going to left there, need to work with it
                    // Just add as much as you can and left 
                    inventoryArray_[index].quantity += freeQuantity;
                    inventoryArray_[index].UpdateQuantity(leftoverQuantity - freeQuantity);
                    return true;
                }
            }
            else {

                // Cannot add item, names doesn't match
                return false;
            }
        }
        else {
            // Add item without problems. Cell is empty

            inventoryArray_[toIndex].copyRefs(inventoryArray_[index]);
            inventoryArray_[index].ClearSlot();

            UpdateFirstFreeSpace(this);
            return true;
        }
    }

    public static bool Transfer(Inventory inv1, Inventory inv2, int indexFrom, int indexTo)
    {

        int leftoverQuantity = inv1[indexFrom].quantity;

        // Something is here...
        if (inv2[indexTo].item != null)
        {
            if (inv2[indexTo].Name == inv1[indexFrom].Name)
            {
                // Merge item with existing (as much quantity as you can)
                int freeQuantity = inv2[indexTo].FreeQuantity;
                if (freeQuantity >= inv1[indexFrom].quantity)
                {
                    // That means we can merge everything without problems
                    inv2[indexTo].quantity += inv1[indexFrom].quantity;
                    inv1[indexFrom].ClearSlot();
                    return true;
                }
                else
                {
                    // Some leftover is going to left there, need to work with it
                    // Just add as much as you can and left 
                    inv2[indexTo].quantity += freeQuantity;
                    inv1[indexFrom].UpdateQuantity(leftoverQuantity - freeQuantity);
                    return true;
                }
            }
            else
            {
                // Cannot add item, names doesn't match
                return false;
            }
        }
        else
        {
            // Add item without problems. Cell is empty
            inv2[indexTo].copyRefs(inv1[indexFrom]);
            inv1[indexFrom].ClearSlot();

            UpdateFirstFreeSpace(inv1.inventoryArray);
            UpdateFirstFreeSpace(inv2.inventoryArray);
            return true;
        }
    }

    public bool Remove(int index) {
        if(inventoryArray_[index].item == null) {
            Debug.LogWarning($"Trying to remove null cell! {index}");
            return false;
        }

        inventoryArray_[index].ClearSlot();
        freeCapacity_ += 1;
        if(index < firstFreePlace_ || firstFreePlace_ == -1) {
            firstFreePlace_ = index;
        }
        return true;
    }

    static void UpdateFirstFreeSpace(InventoryArray inventoryArray) {
        inventoryArray.firstFreePlace_ = searchForNextFreeSpace(inventoryArray);
        if(inventoryArray.firstFreePlace_ == -1) {
            inventoryArray.freeCapacity_ = 0;
        }
    }

    static int searchForNextFreeSpace(InventoryArray inventoryArray) {
        for(int i = 0; i < inventoryArray.Length; i++) {
            if(inventoryArray[i].item == null) return i;
        }
        return -1;
    }
}
