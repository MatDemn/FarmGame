using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropPlaceholder : MonoBehaviour
{
    RectTransform rectTransform;

    public Inventory inventoryRef;

    CanvasGroup canvasGroup;

    public int indexRef;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        indexRef = transform.parent.parent.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
