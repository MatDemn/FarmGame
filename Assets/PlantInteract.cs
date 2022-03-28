using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlantInteract : Interactable
{
    [SerializeField]
    private InvSlotItem invSlotItem;

    public void Start() {

    }
    public override void Interact(GameObject go) {
        base.Interact(go);
        PickUp();
    }

    public void PickUp() {
        Inventory objectAssignedInventory = assignedObject.GetComponent<Inventory>();
        if(objectAssignedInventory != null) {
            if(objectAssignedInventory.Add(invSlotItem)) {
                Destroy(gameObject);
            }
        }
        else {
            Debug.LogWarning("Interaction without inventory attached!");
        }
        
    }
}
