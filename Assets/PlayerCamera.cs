using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Transform myPlayerTransform;

    float cameraTargetRotation = 2f;
    Quaternion playerTargetRotation;

    float targetEulerX;
    float targetEulerY;

    private float sensitivity;
    void Start()

    {
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

        myPlayerTransform = transform.parent;

        sensitivity = 2.0f;

    }

    void Update()

    {
        //Get mouse input and calculate target rotation

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        float mouseY = Input.GetAxis("Mouse Y") * sensitivity; 

        targetEulerY = myPlayerTransform.eulerAngles.y + mouseX;

        playerTargetRotation = Quaternion.Euler(0.0f, targetEulerY, 0.0f);

        cameraTargetRotation -= mouseY;
        cameraTargetRotation = Mathf.Clamp(cameraTargetRotation, -19, 19);
        transform.localEulerAngles = Vector3.right * cameraTargetRotation;

        myPlayerTransform.rotation = playerTargetRotation;

    }
}
