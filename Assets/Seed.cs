using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New seed", menuName = "Inventory/Item/Seed")]
public class Seed : Item
{
    public int growTime;

    public InvSlotItem gatherResult;
}
