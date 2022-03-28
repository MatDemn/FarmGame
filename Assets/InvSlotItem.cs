using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class InvSlotItem
{
    public Item item;

    public int quantity;

    public int maxItemQuantity;

    public string Name {
        get => item != null ? item.name : "/dev/null";
    }

    public InvSlotItem(Item item, int quantity) {
        this.item = item;
        this.quantity = quantity;
        this.maxItemQuantity = 3;
    }

    public void copyRefs(InvSlotItem other)
    {
        this.item = other.item;
        this.quantity = other.quantity;
        this.maxItemQuantity = other.maxItemQuantity;
    }

    public void UpdateQuantity(int quantity) {
        this.quantity = quantity;
    }

    public void ClearSlot() {
        this.item = null;
        this.quantity = 0;
    }

    public int FreeQuantity {
        get => maxItemQuantity - quantity;
    }
}
