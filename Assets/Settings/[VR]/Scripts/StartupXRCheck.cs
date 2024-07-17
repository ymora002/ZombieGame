using System.Collections;
using UnityEngine;

using UnityEngine.XR.Management;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;

public class StartupXRCheck:MonoBehaviour
{
    public bool IsXRInteractions;
    private bool IsDeviceConnected;


    [SerializeField] private InputActionManager inputActionManger;


    [SerializeField] private GameObject[] XRControls;
    public GameObject XRRig;
    [SerializeField] private GameObject XRDesktop;

    public static StartupXRCheck Instance;

    [SerializeField] private MeshRenderer playerModel;

    public PlayerInput PlayerInput;

    private Transform head;
    public Transform origin;
    public Transform target;


    private Camera mainCamera;

    public InputActionAsset InputManager;


    public bool IsXRSession()
    {
        return IsDeviceConnected;
    }


    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
           Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Recenter()
    {
        //API (easy) solution
        /*
        XROrigin xrOrigin = GetComponent<XROrigin>();
        xrOrigin.MoveCameraToWorldLocation(target.position);
        xrOrigin.MatchOriginUpCameraForward(target.up, target.forward);
        */


        //position
        /*
        Vector3 offset = head.position - origin.position;
        offset.y = 0;
        origin.position = target.position;
        */

        //rotation
        //Vector3 targetRotation = new Vector3(pitch, yaw, 0);

        Vector3 targetForward = target.forward;
        targetForward.y = 0;
        Vector3 cameraForward = head.forward;
        cameraForward.y = 0;

        float angle = Vector3.SignedAngle(cameraForward, targetForward, Vector3.up);

        origin.RotateAround(head.position, Vector3.up, angle);
    }

    private void Awake()
    {
        

        Application.runInBackground = true;

        Instance = this;

        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            //xrInteractionManger.enabled = true;

            if (QualitySettings.lodBias <= 1)
                QualitySettings.lodBias *= 3.8f;

            IsDeviceConnected = true;

            XRRig.SetActive(true);
            XRDesktop.SetActive(false);

            if (IsXRInteractions)
            {
                foreach (GameObject controller in XRControls)
                {
                    controller.SetActive(true);
                }
            }
        }
        else
        {
            IsDeviceConnected = false;

            //xrInteractionManger.enabled = false;
            XRDesktop.SetActive(true);

            foreach (GameObject controller in XRControls)
            {
                controller.SetActive(false);
            }
        }


    }


    private void Start()
    {

        if (PlayerInput.actions != InputManager)
        {
            PlayerInput.actions = InputManager;

        }

        PlayerInput.enabled = true;

        Cursor.visible = false;
        playerModel.enabled = false;

        mainCamera = Camera.main;
        head = mainCamera.transform;
    }
}