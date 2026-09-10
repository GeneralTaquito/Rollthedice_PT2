using TMPro;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    [Header("Speeds")] // Configurable speed variables
    [SerializeField] private float WalkSpeed = 3.0f;
    [SerializeField] private float SprintMult = 2.0f;

    [Header("Jumping")] // Jump configurables
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float gravity = 9.81f;

    [Header("Sensitivity")] // Sensitivity and clamp range
    [SerializeField] private float mouseSens = 2.0f;
    [SerializeField] private float upDownRange = 80.0f;

    [Header("Inputs")] // Configurable inputs from the old input system and input keys
    [SerializeField] private string horizontalMoveInput = "Horizontal";
    [SerializeField] private string verticalMoveInput = "Vertical";
    [SerializeField] private string MouseXInput = "Mouse X";
    [SerializeField] private string MouseYInput = "Mouse Y";
    [SerializeField] private KeyCode sprintkey = KeyCode.LeftShift;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    private Camera mainCamera;
    private float verticalRotation;
    private CharacterController charCon;
    private Vector3 currentMovement = Vector3.zero;

    private void Start()
    {
        charCon = GetComponent<CharacterController>();
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleEffects();
    }


    public void HandleMovement()
    {

        float speedmult1 = Input.GetKey(sprintkey) ? SprintMult : 1f; // For future reference "?" is like a true and false that triggers what is after it
        float verticalSpeed = Input.GetAxis(verticalMoveInput) * WalkSpeed * speedmult1; // state the vertical speed variable by multiplying the input systems "Vertical" to walkspeed
        float horizontalSpeed = Input.GetAxis(horizontalMoveInput) * WalkSpeed * speedmult1; // same here for horizontal (also adding speed multipliers here

        Vector3 horizontalMovement = new Vector3(horizontalSpeed, 0, verticalSpeed);
        horizontalMovement = transform.rotation * horizontalMovement;

        HandleJumping();

        currentMovement.x = horizontalMovement.x;
        currentMovement.z = horizontalMovement.z;

        charCon.Move(currentMovement * Time.deltaTime);
    }

    void HandleEffects()
    {
        //fancy fov sprint juice
        if (Input.GetKey(sprintkey))
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 120f, Time.deltaTime * 2f); // both lines basically just lerp from 90 fov to 120 and vice versa
            Debug.Log("fovchange");
        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 90f, Time.deltaTime * 2f);
        }
    }
    void HandleJumping()
    {
        if (charCon.isGrounded)
        {
            currentMovement.y = -0.5f; // to stay grounded

            if (Input.GetKeyDown(jumpKey))
            {
                currentMovement.y = jumpForce; //jumping..
            }
        }
        else
        {
            currentMovement.y -= gravity * Time.deltaTime; // grounding (with gravity)
        }
    }
    void HandleRotation()
    {
        float mouseXRotation = Input.GetAxis(MouseXInput) * mouseSens;
        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= Input.GetAxis(MouseYInput) * mouseSens; // Fetching the input system
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange); // Clamps the mouse to not go beyond the vertical limits 
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0); // Fixing the camera to the rotations
    }
}
