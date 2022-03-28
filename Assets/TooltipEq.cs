using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipEq : TooltipBase
{
    [SerializeField]
    Text textField;

    RectTransform rectReansform;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        rectReansform = transform.GetComponent<RectTransform>();
        InventorySlot.OnMouseEnter += ShowToolTip;
        InventorySlot.OnMouseExit += HideToolTip;
    }

    void Update()
    {
        Vector3 newPos = (Vector3)Input.mousePosition;
        rectReansform.position = newPos;
    }

    void ShowToolTip(InvSlotItem invSlotItem) {
        textField.text = invSlotItem.Name;
        gameObject.SetActive(true);
    }

    void HideToolTip() {
        textField.text = "";
        gameObject.SetActive(false);
    }
}
