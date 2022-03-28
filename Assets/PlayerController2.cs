using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public CharacterController charController;

    public Camera playerCam; 

    float rotationAmount = 0f;

    public float mouseSensitivity;

    public float walkSpeed;

    public float runSpeed;

    public bool canMoveCamera;
    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = 5f;

        walkSpeed = 3f;

        runSpeed = 3f;

        LockCamera(false);
    }

    // Update is called once per frame
    void Update()
    {
        float v_move = Input.GetAxis("Vertical");
        float h_move = Input.GetAxis("Horizontal");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if(canMoveCamera) {
            rotationAmount -= mouseY * mouseSensitivity;
            rotationAmount = Mathf.Clamp(rotationAmount, -90f, 90f);

            playerCam.transform.localRotation = Quaternion.Euler(rotationAmount, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX * mouseSensitivity);


            Vector3 moveVector = transform.right * h_move + transform.forward * v_move;
            charController.SimpleMove(moveVector * walkSpeed/*  Time.deltaTime*/);
        }
        


    }

    public void LockCamera(bool state)
    {
        if(state)
        {
            canMoveCamera = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            canMoveCamera = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }
}
