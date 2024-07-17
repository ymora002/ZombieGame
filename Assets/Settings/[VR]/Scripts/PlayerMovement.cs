using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private XRDeviceSimulator desktopMove;
    [SerializeField] private ActionBasedContinuousMoveProvider xrMove;

    #region
    /*
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float gravity = -15f;

    private Vector3 velocity;

    private bool isGrounded;
    */

    /*
     public CharacterController _controller;
     public float horizontalInput;
     public float verticalInput;

     public float MAX_SPEED = 10f;
     public float incrementRate = 0.15f;
     private float playerSpeed;
     public float turnspeed = 100f;
    */

    #endregion

    public float BASE_SPEED_XR = 3f;
    public float BASE_SPEED_DESKTOP = 15f;

    private bool wasInObstacle;
    private bool isMoving;
    private bool isSprinting;

    public bool wasInteracting = false;

    private Vector2 inputMove;
    private Vector2 lastMove;

    public static PlayerMovement Instance;

    private void Awake()
    {
        Instance = this;
        inputMove = Vector2.zero;
        lastMove = Vector2.zero;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputMove = context.ReadValue<Vector2>();
        isMoving = true;
    }


    public void OnInteract(InputAction.CallbackContext context)
    {


        if (context.action.triggered)
        {

            wasInteracting = true;



        }
        else
        {
            wasInteracting = false;
        }

    }

    public void OnSprintAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSprinting = true;
        }
        else if (context.canceled)
        {
            isSprinting = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region
        /*
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        */


        /*
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        */

        //MovePlayer();
        #endregion
        CheckSprinting();
        if (!isMoving)
        {
            desktopMove.keyboardBodyTranslateMultiplier = 0;
            xrMove.moveSpeed = 0;
        }


    }

    public void CheckSprinting()
    {

        if (isSprinting)
        {
            desktopMove.keyboardBodyTranslateMultiplier = BASE_SPEED_DESKTOP * 2;
            xrMove.moveSpeed = BASE_SPEED_XR * 2;

        }
        else
        {
            desktopMove.keyboardBodyTranslateMultiplier = BASE_SPEED_DESKTOP;
            xrMove.moveSpeed = BASE_SPEED_XR;

        }
    }

    #region
    /*
    public void MovePlayer()
    {
        Vector3 movement = new Vector3(inputMove.x, 0, inputMove.y);

        if (movement != Vector3.zero)
            _controller.transform.rotation = Quaternion.Slerp
               (_controller.transform.rotation, Quaternion.LookRotation(movement), 0.15f);

        if (inputMove.y > 0)
        {
            playerSpeed = Mathf.Lerp(playerSpeed, MAX_SPEED, incrementRate);
        }
        else
        {
            playerSpeed = Mathf.Lerp(playerSpeed, 0, incrementRate);
        }

        _controller.Move(movement * playerSpeed * Time.deltaTime);
    }
    */
    #endregion


    private void OnTriggerEnter(Collider other)
    {

        if (LayerMask.LayerToName(other.gameObject.layer) != "Body")
        {
            wasInObstacle = true;
            isMoving = false;
            lastMove = inputMove;

        }

    }
}
