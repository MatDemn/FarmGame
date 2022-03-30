using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDropIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RectTransform rectTransform;

    static Transform dragDropPlaceHolder;

    Transform backupParent;

    public InventorySlot invSlot;

    Canvas canvas;

    CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if(dragDropPlaceHolder == null)
            dragDropPlaceHolder = GameObject.Find("DragIconPlaceholder").transform;
        invSlot = transform.parent.GetComponent<InventorySlot>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas ??= GameObject.Find("UI").GetComponent<Canvas>();
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
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, pointerData.position, canvas.worldCamera, out pos);
        rectTransform.transform.position = canvas.transform.TransformPoint(pos);
    }

    public void OnEndDrag(PointerEventData pointerData) {
        transform.SetParent(backupParent.transform);
        rectTransform.anchoredPosition = Vector2.zero;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }
}
