using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLoop : MonoBehaviour
{

    public float mouseSensitivity = 250f;
    public float minXAngle = -80f;
    public float maxXAngle = 90f;
    Transform playerBody;
    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;
    public CursorLockMode mode;
    

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = mode;
        playerBody = gameObject.transform.parent;


    }

    // Update is called once per frame
    void Update()
    {
        
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        playerBody.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minXAngle, maxXAngle);
        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        
        
    }
}
