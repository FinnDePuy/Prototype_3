using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Camera playerCamera;

    private float speed = 5.0f;
    private float gravity = 30.0f;

    private float lookSpeedX = 2.0f;
    private float lookSpeedY = 2.0f;

    private Vector3 moveDirection;
    private Vector2 currentInput;
    private float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //culmination of WASD and mouse movement
        controlPlayerMovement();
        controlPlayerCamera();
        //applying Gravity to the player
        applyGravity();
    }

    private void controlPlayerMovement()
    {
        currentInput = new Vector2(speed * Input.GetAxis("Vertical"), speed * Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirection.y;

        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void controlPlayerCamera()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -80, 80);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

    private void applyGravity(){
        if(!characterController.isGrounded){
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);
    }
}