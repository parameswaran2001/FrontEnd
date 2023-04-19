using UnityEngine;
using UnityEngine.AI;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float distance = 3.0f;
    public float height = 1.5f;
    public LayerMask obstructionLayer;

    private Camera _camera;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _initialPosition;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _navMeshAgent = target.GetComponent<NavMeshAgent>();
        _initialPosition = target.position;
    }

    private void LateUpdate()
    {
        // Calculate the desired camera position
        Vector3 targetPosition = target.position + target.forward * distance + Vector3.up * height;

        // Check if any objects obstruct the view
        RaycastHit hit;
        if (Physics.Linecast(target.position + Vector3.up * height, targetPosition, out hit, obstructionLayer))
        {
            // Move the camera to the position just before the obstruction
            _camera.transform.position = hit.point + hit.normal * 0.5f;
        }
        else
        {
            // Move the camera to the desired position
            _camera.transform.position = targetPosition;
        }

        // Look at the target
        _camera.transform.LookAt(target.position);

        // Unrender obstructing objects
        if (_navMeshAgent != null)
        {
            NavMeshPath path = new NavMeshPath();
            if (_navMeshAgent.CalculatePath(_camera.transform.position, path))
            {
                for (int i = 1; i < path.corners.Length; i++)
                {
                    Vector3 corner = path.corners[i];
                    RaycastHit obstacleHit;
                    if (Physics.Linecast(_camera.transform.position, corner, out obstacleHit, obstructionLayer))
                    {
                        Renderer renderer = obstacleHit.transform.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.enabled = false;
                        }
                    }
                }
            }
        }
    }

    public void ResetCameraPosition()
    {
        _camera.transform.position = _initialPosition + Vector3.up * height + target.forward * distance;
        _camera.transform.LookAt(target.position);
    }
}
