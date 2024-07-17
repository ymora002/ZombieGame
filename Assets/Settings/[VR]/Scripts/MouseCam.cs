using UnityEngine;
using System.Collections;

public class MouseCam: MonoBehaviour 
{

    public float speedH = 2.5f;
    public float speedV = 2.5f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Application is focussed");
        }
        else
        {
            Debug.Log("Application lost focus");
        }
    }

    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;
        yaw = transform.rotation.eulerAngles.y;


    }

    void Update ()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);


    }

    public void SetPitchYaw(float inputPitch, float inputYaw)
    {
        pitch = inputPitch;
        yaw = inputYaw;
    }

}
