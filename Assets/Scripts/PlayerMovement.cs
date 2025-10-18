using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(getPlayerInputDirection());
    }

    private Vector3 getPlayerInputDirection()
    {
        Vector3 direction = Vector3.zero;
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;
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
        return direction.normalized;
    }
}
