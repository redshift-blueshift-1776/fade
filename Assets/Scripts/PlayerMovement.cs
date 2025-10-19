using TMPro;
using UnityEngine;

using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private GameObject playerCamera;
    [SerializeField] private CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float sensitivityX = 2.5f;
    private float sensitivityY = 2;

    public Slider sliderX;
    public Slider sliderY;

    public Slider fovSlider;
    public TMP_Text fovText;

    private float yaw;
    private float pitch;

    private const float mass = 1.0f;
    private Vector3 velocity = Vector3.zero;

    private const float swimmingForce = 3f;
    private const float fastSwimmingForce = 7f;
    private const float swimmingResistiveCoefficient = 0.25f;

    private const float minComponentVelocityThreshold = 0.01f;

    public bool isBoosting;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw = transform.localRotation.eulerAngles.y;
        pitch = transform.localRotation.eulerAngles.x;
        while (Mathf.Abs(yaw) > 180f)
        {
            yaw -= Mathf.Sign(yaw) * 360f;
        }

        sensitivityX = sliderX.value;
        sensitivityY = sliderY.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            moveCamera();
        }
        handleSensitivityChange();

        if (Camera.main != null)
        {
            Camera.main.fieldOfView = Mathf.Clamp(30f, fovSlider.value, 120f);
            fovText.text = Camera.main.fieldOfView.ToString();
        }
    }

    void FixedUpdate()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        bool isFastSwimming = Input.GetKey(KeyCode.LeftShift);
        isBoosting = isFastSwimming;

        Vector3 playerForce = (isFastSwimming ? fastSwimmingForce : swimmingForce)
        * getPlayerInputDirection();

        Vector3 resistiveForce = -velocity.normalized;
        float resistiveForceComponent = swimmingResistiveCoefficient * velocity.magnitude;
        resistiveForce *= resistiveForceComponent;

        Vector3 netForce = playerForce + resistiveForce;

        Vector3 acceleration = netForce / mass;

        velocity += acceleration;

        handleVelocityConstraints();

        controller.Move(velocity * Time.deltaTime);
    }
    
    private void handleVelocityConstraints()
    {
        if (Mathf.Abs(velocity.x) < minComponentVelocityThreshold)
        {
            velocity.x = 0;
        }

        if (Mathf.Abs(velocity.y) < minComponentVelocityThreshold)
        {
            velocity.y = 0;
        }

        if (Mathf.Abs(velocity.z) < minComponentVelocityThreshold)
        {
            velocity.z = 0;
        }
    }
    private Vector3 getPlayerInputDirection()
    {
        Vector3 direction = Vector3.zero;
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        
        if (Input.GetKey(KeyCode.W))
        {
            direction += forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction -= right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction -= forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += right;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            direction += Vector3.down;
        }
        return direction.normalized;
    }

    private void moveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        yaw += mouseX;
        pitch -= mouseY; //inverted
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.localRotation = Quaternion.Euler(pitch, yaw, 0);
    }

    private void handleSensitivityChange()
    {
        sensitivityX = sliderX.value;
        sensitivityY = sliderY.value;
    }
}
