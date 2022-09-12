using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class walking_code : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    bool isRunning = false;
    public float runningSpeed = 15f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public Slider StaminaSlider;
    public static int Maxstamina = 1000;
    public int useStamina = 10;
    public int forceStamina = 5;
    public float DebutDogTime = 5.0f;
    bool hitDog = false;
    public GameObject DebutIcon;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "boss")
        {
            Time.timeScale = 0;
        }
        if (collider.gameObject.tag == "Dog")
        {
            hitDog = true;
        }
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StaminaSlider.maxValue = Maxstamina;
        StaminaSlider.value = Maxstamina;
        DebutIcon.SetActive(false);
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        if (Input.GetKey(KeyCode.LeftShift) && StaminaSlider.value > 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        if (isRunning == true && StaminaSlider.value > 0)
        {
            StaminaSlider.value -= useStamina;
        }
        else if (StaminaSlider.value == 0)
        {
            isRunning = false;
        }
        if (StaminaSlider.value < StaminaSlider.maxValue)
        {
            StaminaSlider.value += forceStamina;
        }
        if (hitDog == true)
        {
            DebutIcon.SetActive(true);
            useStamina = 20;
            if (DebutDogTime >= 0)
            {
                DebutDogTime -= Time.deltaTime;
            }
            if (DebutDogTime == 0 || DebutDogTime <=0)
            {
                useStamina = 10;
                DebutDogTime = 5.0f;
                hitDog = false;
                DebutIcon.SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.E) && StaminaSlider.value < StaminaSlider.maxValue/2)
        {
            if (itemmanager.haveWater == true)
            {
                if (itemmanager.haveWater2 == true)
                {
                    StaminaSlider.value = Maxstamina;
                    itemmanager.haveWater2 = false;
                }
                else
                {
                    StaminaSlider.value = Maxstamina;
                    itemmanager.haveWater = false;
                }
            }
        }

        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove && Time.timeScale == 1)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}