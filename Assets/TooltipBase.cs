using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipBase : MonoBehaviour
{
    public Text tooltipText;

    public LayerMask actionMask;

    public float actionRadius;

    public virtual void Start() {
        tooltipText = GetComponentInChildren<Text>();
        actionMask = LayerMask.GetMask("PlayerAction");
        actionRadius = 2.5f;
    }

    protected void ChangeText(string text) {
        tooltipText.text = text;
    }
}
