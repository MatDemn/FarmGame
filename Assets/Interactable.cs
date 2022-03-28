using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactable : MonoBehaviour
{
    public string desc;
    public float radius = 2.5f;

    // Which object interacted with it?
    public GameObject assignedObject;

    public virtual void Interact(GameObject go) {
        assignedObject = go;
    }
}
