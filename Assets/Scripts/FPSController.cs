using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("Player Settings")]
    public float walkSpeed = 5f;
    public float crouchSpeed = 2.5f;
    public float jumpHeight = 1.2f;
    public float gravity = -20f;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 200f;
    public Transform playerCamera;

    [Header("Crouch Settings")]
    public float standingHeight = 1.8f;
    public float crouchHeight = 1.0f;
    public float crouchSmooth = 10f;

    float xRotation = 0f;
    float yVelocity;
    CharacterController controller;

    public static bool freezeMovement = false;
    public static bool allowJumpOnly = false;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        // FIX: make sure movement and jump are normal at start
        allowJumpOnly = true;

        Cursor.lockState = CursorLockMode.Locked; // Hide mouse
    }

    void Update()
    {
        LookAround();
        MovePlayer();
    }

    // ------------------ MOUSE LOOK ------------------
    void LookAround()
    {
        if (freezeMovement) return;   // Stop look

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    // ------------------ MOVEMENT ------------------
    void MovePlayer()
    {
        bool isGrounded = controller.isGrounded;

        // If movement is frozen → only allow jump
        if (freezeMovement)
        {
            JumpOnly(isGrounded);
            return;
        }

        float speed = Input.GetKey(KeyCode.LeftShift) ? crouchSpeed : walkSpeed;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Normal jump
        JumpOnly(isGrounded);

        HandleCrouch();
    }


    // ------------------ CROUCH ------------------
    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // crouch
        {
            controller.height = Mathf.Lerp(controller.height, crouchHeight, Time.deltaTime * crouchSmooth);
        }
        else // stand
        {
            controller.height = Mathf.Lerp(controller.height, standingHeight, Time.deltaTime * crouchSmooth);
        }
    }

    void JumpOnly(bool isGrounded)
    {
        if (allowJumpOnly)
        {
            if (isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
            }
        }

        yVelocity += gravity * Time.deltaTime;
        controller.Move(new Vector3(0, yVelocity, 0) * Time.deltaTime);
    }

}
