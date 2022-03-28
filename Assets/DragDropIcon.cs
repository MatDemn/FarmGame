using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RectTransform rectTransform;

    static Transform dragDropPlaceHolder;

    Transform backupParent;

    public InventorySlot invSlot;

    CanvasGroup canvasGroup;

    public int indexRef;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if(dragDropPlaceHolder == null)
            dragDropPlaceHolder = GameObject.Find("DragIconPlaceholder").transform;
        invSlot = transform.parent.parent.GetComponent<InventorySlot>();
        canvasGroup = GetComponent<CanvasGroup>();
        indexRef = transform.parent.parent.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData pointerData) {
        backupParent = transform.parent;
        transform.SetParent(dragDropPlaceHolder);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;


        /*
         There should be an object on placeholder
        that serves as drag an drop ghost.
        It could be used for left and right click.
        Just the behaviour is different.

        Simpler than coding left and right click
        completely different.
         */

        // If Left button was pressed
        if(pointerData.button == PointerEventData.InputButton.Left)
        {

        }
        // If right button was pressed
        else if (pointerData.button == PointerEventData.InputButton.Right)
        {

        }
        else
        {
            Debug.Log("Wrong button pressed ;/");
        }
    }

    public void OnDrag(PointerEventData pointerData) {
        rectTransform.anchoredPosition += pointerData.delta;
    }

    public void OnEndDrag(PointerEventData pointerData) {
        transform.SetParent(backupParent.transform);
        rectTransform.anchoredPosition = Vector2.zero;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }
}
