using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public float senX;
    public float senY;

    public float rotationX; // Vertical Rotation
    public float rotationY; //Horizontal Rotation

    public Transform orientation;

    public Transform gunOrientation;

    public Transform playerCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * senX * Time.deltaTime;
        rotationY += mouseX;


        float mouseY = Input.GetAxisRaw("Mouse Y") * senX * Time.deltaTime;
        rotationX -= mouseY;

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);

        gunOrientation.rotation = Quaternion.Euler(rotationX, rotationY, 0);

        orientation.rotation = Quaternion.Euler(0, rotationY, 0);

        transform.position = playerCameraPos.position;

    }
}
