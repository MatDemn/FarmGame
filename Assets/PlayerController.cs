using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;

    public float rotateSpeed;

    public Camera camRef;
    // Start is called before the first frame update
    void Start()
    {
        walkSpeed = 5f;
        rotateSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float h_move = Input.GetAxis("Horizontal");
        float v_move = Input.GetAxis("Vertical");
        float h_rot = Input.GetAxis("Mouse X");
        float v_rot = Input.GetAxis("Mouse Y");

        movePlayer(new Vector3(h_move, 0, v_move));
        rotatePlayer(h_rot, v_rot);
    }
    public void movePlayer(Vector3 moveDir) {
        transform.position += moveDir * Time.deltaTime * walkSpeed;
    }

    public void rotatePlayer(float h_rot, float v_rot) {
        transform.Rotate(0, h_rot, 0);
        camRef.transform.Rotate(v_rot, 0, 0);
    }
}
