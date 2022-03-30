using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;

    [SerializeField]
    private Transform equipCellsParent;
    private InventorySlot[] equipCells;

    public Transform inventoryContentFirstElem;

    float lastTimeInvoked;

    float inventoryUICooldown;

    public PlayerController2 charController;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Inventory>();
        inventory.onItemAddedCallback += AddItemUI;
        inventory.onItemDeletedCallback += RemoveItemUI;
        inventory.onItemUpdatedCallback += UpdateItemUI;
        inventory.onInventoryButtonCallback += InventoryUIFunc;
        equipCells = equipCellsParent.GetComponentsInChildren<InventorySlot>();
        inventoryContentFirstElem = transform.GetChild(0);
        lastTimeInvoked = Time.time;
        inventoryUICooldown = .5f;
        charController = inventory.gameObject.GetComponent<PlayerController2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddItemUI(List<int> indexes) {
        foreach(int i in indexes) {
            equipCells[i].AddItem(inventory.inventoryArray[i]);
        }
    }

    void RemoveItemUI(List<int> indexes) {
        foreach(int index in indexes)
            equipCells[index].DelItem();
    }

    void UpdateItemUI(List<int> indexes)
    {
        foreach(int i in indexes)
        {
            equipCells[i].UpdateItem();
        }
    }

    public void RemoveItemInventory(int index) {
        bool removeItem = inventory.Remove(index);
        if(!removeItem) {
            Debug.LogWarning($"Tried to remove {index} cell, but it failed...");
        }
    }

    public void InventoryUIFunc() {
        if(lastTimeInvoked + inventoryUICooldown < Time.time)
        {
            if(inventoryContentFirstElem.gameObject.activeInHierarchy)
            {
                InventoryUIFuncDisable();
            }
                
            else {
                InventoryUIFuncEnable();
            }
                
            lastTimeInvoked = Time.time;
        }
    }

    public void InventoryUIFuncEnable()
    {
        foreach (Transform elem in transform)
        {
            elem.gameObject.SetActive(true);
        }
        charController.LockCamera(true);
    }

    public void InventoryUIFuncDisable()
    {
        foreach (Transform elem in transform)
        {
            elem.gameObject.SetActive(false);
        }
        charController.LockCamera(false);
    }
}
