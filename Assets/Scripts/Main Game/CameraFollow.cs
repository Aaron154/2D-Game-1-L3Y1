using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;  // The object the camera should follow
    public float smoothTime = 0.5f; // The smoothing time for the camera movement
    public float sizeMultiplier = 0.1f; // Multiplier for how much the camera size changes with speed
    public float minCameraSize = 5f; // Minimum camera size
    public float maxCameraSize = 10f; // Maximum camera size
    public float sizeSmoothTime = 0.3f; // How smooth the camera size transitions

    private Vector2 velocity = Vector2.zero; // SmoothDamp velocity for camera movement
    private Camera cam;  // Reference to the camera component
    private Vector2 lastTargetPosition; // Stores the last position of the target
    private float currentVelocity = 0f;  // Used to smooth the camera size transitions

    void Start()
    {
        cam = GetComponent<Camera>();
        lastTargetPosition = followTarget.position; // Initialize with the current target's position
    }

    void LateUpdate()
    {
        Vector2 targetPosition = followTarget.position;

        // Smoothly follow the target
        Vector2 newPosition = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z); // Set new camera position, keeping the z-axis fixed

        // Calculate target's speed based on the change in position
        float targetSpeed = (targetPosition - lastTargetPosition).magnitude / Time.deltaTime;

        // Calculate new camera size based on target speed
        float targetCameraSize = Mathf.Lerp(minCameraSize, maxCameraSize, targetSpeed * sizeMultiplier);

        // Smoothly adjust the camera size
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetCameraSize, ref currentVelocity, sizeSmoothTime);

        // Store current target position for the next frame
        lastTargetPosition = followTarget.position;
    }

    // Switch to a new camera target
    public void SwitchCameraTargets(Transform newCameraTarget)
    {
        followTarget = newCameraTarget;
        lastTargetPosition = followTarget.position;  // Reset position to avoid spikes in speed
    }
}