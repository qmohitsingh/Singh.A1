using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera firstPersonCamera; // Assign in the Inspector
    public Camera thirdPersonCamera; // Assign in the Inspector

    private bool isInFirstPerson = false; // Start in first person by default

    void Start()
    {
        // Ensure correct initial setup
        firstPersonCamera.enabled = isInFirstPerson;
        thirdPersonCamera.enabled = !isInFirstPerson;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TogglePerspective();
        }
    }

    void TogglePerspective()
    {
        isInFirstPerson = !isInFirstPerson; // Toggle the state
        firstPersonCamera.enabled = isInFirstPerson; // Enable/disable the first person camera
        thirdPersonCamera.enabled = !isInFirstPerson; // Enable/disable the third person camera
    }
}
