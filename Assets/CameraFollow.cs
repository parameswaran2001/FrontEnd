using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // The target to follow (NavMesh agent)
    public float smoothSpeed = 0.125f;     // The smoothness of camera movement
    public Vector3 offset;         // The offset from the target position
    public float distance = 5f;     // The distance between the camera and the target
    public float rotationSpeed = 5f;     // The speed of camera rotation
    public float minVerticalAngle = -45f;   // The minimum vertical angle of the camera (in degrees)
    public float maxVerticalAngle = 45f;    // The maximum vertical angle of the camera (in degrees)

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position by applying the offset and distance to the target's position
            Vector3 desiredPosition = target.position + offset - target.forward * distance;

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Rotate the camera to look at the target
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

            // Adjust camera angles to ensure the agent is visible
            AdjustCameraAngles();
        }
    }

    private void AdjustCameraAngles()
    {
        // Calculate the direction from the camera to the target
        Vector3 direction = target.position - transform.position;

        // Calculate the vertical angle between the camera and the target
        float verticalAngle = Vector3.Angle(direction, transform.forward);

        // Clamp the vertical angle to ensure it stays within the defined range
        verticalAngle = Mathf.Clamp(verticalAngle, minVerticalAngle, maxVerticalAngle);

        // Calculate the new rotation around the x-axis (vertical axis)
        Quaternion newRotation = Quaternion.Euler(verticalAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        // Apply the new rotation to the camera
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
    }
}
