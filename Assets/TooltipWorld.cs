using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipWorld : TooltipBase
{
    public override void Start() {
        base.Start();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)), out hit, actionRadius, actionMask)) {
            Interactable other = hit.collider.gameObject.GetComponent<Interactable>();
            if(other != null) {
                ChangeText(other.desc);
            }
            else {
                ChangeText("");
            }
        }
        else {
            ChangeText("");
        }
    }
}
