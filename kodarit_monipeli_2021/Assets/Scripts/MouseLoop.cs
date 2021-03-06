using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;


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
    CinemachineVirtualCamera vcam;
    PhotonView view;
    

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = mode;
        playerBody = gameObject.transform.parent;
        view = playerBody.GetComponent<PhotonView>();
        vcam = GetComponent<CinemachineVirtualCamera>();

        if(!view.IsMine){

            vcam.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if(view.IsMine){

            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, minXAngle, maxXAngle);
            transform.localRotation = Quaternion.Euler(xRotation,0,0);
            playerBody.Rotate(Vector3.up * mouseX);

        }
        
        
        
        
    }
}
