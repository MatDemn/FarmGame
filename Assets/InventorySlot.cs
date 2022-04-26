using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class InventorySlot : Slot, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public Canvas canvas;
    public InvSlotItem invSlotItem;

    public Inventory inventory;
    public Image icon;

    public int cellIndex;

    public TextMeshProUGUI quantityText;

    public static Action<InvSlotItem> OnMouseEnter;

    public static Action OnMouseExit;

    [SerializeField]
    bool droppableSlot;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("UI").GetComponent<Canvas>();

        invSlotItem = inventory.inventoryArray[cellIndex];

        if (inventory == null)
        {
            Debug.LogError($"No Inventory Ref! {gameObject.name}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(InvSlotItem newInvSlotItem) {
        invSlotItem = newInvSlotItem;
        icon.sprite = invSlotItem.item.icon;
        icon.enabled = true;

        UpdateQuantity();
        quantityText.gameObject.SetActive(true);
    }

    public void DelItem() {
        // Add dropping to the ground if necessary...

        invSlotItem.item = null;
        icon.sprite = null;
        icon.enabled = false;

        quantityText.gameObject.SetActive(false);
    }

    public void UpdateQuantity() {
        if(invSlotItem.quantity < 2)
            quantityText.text = "";
        else
            quantityText.text = invSlotItem.quantity.ToString();
    }

    public void UpdateItem()
    {
        if (invSlotItem.item != null)
        {
            icon.sprite = invSlotItem.item.icon;
            icon.enabled = true;
            quantityText.gameObject.SetActive(true);
        }
        else
        {
            icon.sprite = null;
            icon.enabled = false;
            quantityText.gameObject.SetActive(false);
        }
        UpdateQuantity();
    }



    public void OnPointerEnter(PointerEventData eventData) {
        OnMouseEnter?.Invoke(invSlotItem);
    }

    public void OnPointerExit(PointerEventData eventData) {
        OnMouseExit?.Invoke();
    }

    public void OnDrop(PointerEventData eventData) {
        DragDropIcon dragDropRef = eventData.pointerDrag.GetComponent<DragDropIcon>();
        if (dragDropRef != null && droppableSlot) {

            if (DragDropTransfer(dragDropRef, this))
                return;
            Debug.LogWarning("OnDrop Transfer failed...");
        }
    }

    bool DragDropTransfer(DragDropIcon dragDropIcon, InventorySlot invSlotDest)
    {
        Inventory fromInv = dragDropIcon.invSlot.inventory;
        Inventory toInv = invSlotDest.inventory;
        int indexFrom = dragDropIcon.invSlot.cellIndex;
        int indexTo = cellIndex;

        return Inventory.Transfer(fromInv, toInv, indexFrom, indexTo);
    }


}
