using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensitivity = 1000f;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate the camera (attached to the player's head) vertically
        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player's body horizontally
        playerBody.Rotate(Vector3.up * mouseX);
        
        //yRotation -= mouseX;
        //yRotation = Mathf.Clamp(-90f, yRotation, 90f);

        //transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);

        //playerBody.Rotate(Vector3.up * mouseY);
    }
}
