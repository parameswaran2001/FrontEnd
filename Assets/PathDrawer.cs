using UnityEngine;
using UnityEngine.AI;

public class PathDrawer : MonoBehaviour
{
    private NavMeshAgent agent;
    private LineRenderer lineRenderer;
    private bool isPathDrawn = false;
    private GameObject goalObject;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;

        // Find the GameObject based on the selectedValue2
        goalObject = GameObject.Find(TargetDestinationDropdown.selectedValue2);
    }

    void Update()
    {
        if (!isPathDrawn && goalObject != null)
        {
            CalculateAndDrawShortestPath();
        }
    }

    void CalculateAndDrawShortestPath()
    {
        Vector3 goalPosition = goalObject.transform.position;

        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(goalPosition, path);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            lineRenderer.positionCount = path.corners.Length;
            lineRenderer.SetPositions(path.corners);
        }
        else
        {
            lineRenderer.positionCount = 0;
        }

        isPathDrawn = true;
    }
}
