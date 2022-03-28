using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftingSlot : Slot
{
    [SerializeField]
    InvSlotItem invSlotItem;

    [SerializeField]
    Image icon;

    [SerializeField]
    Text quantityText;

    public static Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        if(inventory == null)
        {
            inventory = transform.parent.parent.GetComponent<Inventory>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(InvSlotItem newInvSlotItem)
    {
        invSlotItem = newInvSlotItem;
        icon.sprite = invSlotItem.item.icon;
        icon.enabled = true;

        UpdateQuantity();
        quantityText.gameObject.SetActive(true);
    }

    public void DelItem()
    {
        // Add dropping to the ground if necessary...

        invSlotItem.item = null;
        icon.sprite = null;
        icon.enabled = false;

        quantityText.gameObject.SetActive(false);
    }

    public void UpdateQuantity()
    {
        if (invSlotItem.quantity < 2)
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
}
