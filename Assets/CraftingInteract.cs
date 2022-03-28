using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingInteract : Interactable
{
    [SerializeField]
    GameObject craftingScreen;

    PlayerController2 playerController;

    [SerializeField]
    InventoryUI playerInventoryUIObj;
    
    InventoryUI playerInventoryUI;

    bool isEnabled;
    // Start is called before the first frame update
    void Start()
    {
        playerInventoryUI = playerInventoryUIObj.GetComponent<InventoryUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnabled && Input.GetAxis("Inventory") > 0)
        {
            craftingScreen.SetActive(false);
            isEnabled = false;
            playerInventoryUI.InventoryUIFuncDisable();
        }
    }

    public override void Interact(GameObject go)
    {
        base.Interact(go);
        playerController = go.GetComponent<PlayerController2>();

        if(playerController)
        {
            craftingScreen.SetActive(true);
            isEnabled = true;
            playerInventoryUI.InventoryUIFuncEnable();
        }


    }
}
