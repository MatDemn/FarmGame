using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float actionRadius = 2.5f;
    public LayerMask actionMask;

    public PlayerController2 playerControl;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = gameObject.GetComponent<PlayerController2>();
    }

    // Update is called once per frame
    void Update()
    {   
        RaycastHit hit;
        if(playerControl.canMoveCamera && Input.GetAxis("Fire1") != 0) {
            if(Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)), out hit, actionRadius, actionMask)) {
                Interactable other = hit.collider.gameObject.GetComponent<Interactable>();
                if(other != null) {
                    other.Interact(gameObject);
                }
            }
            
        }
    }
}
