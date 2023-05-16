using UnityEngine;

public class HighlightObjects : MonoBehaviour
{
    public Material highlightMaterial; // The material used for highlighting

    private GameObject initialNavMeshObject;
    private GameObject goalObject;

    void Start()
    {
        // Find the initial NavMesh object based on selectedValue1
        initialNavMeshObject = GameObject.Find(CurrentLocationDropdown.selectedValue1);

        // Find the goal object based on selectedValue2
        goalObject = GameObject.Find(TargetDestinationDropdown.selectedValue2);

        HighlightObject(initialNavMeshObject);
        HighlightObject(goalObject);
    }

    void HighlightObject(GameObject obj)
    {
        if (obj != null)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = highlightMaterial;
            }
            else
            {
                Debug.LogWarning("Renderer component not found on object: " + obj.name);
            }
        }
        else
        {
            Debug.LogWarning("Object not found.");
        }
    }
}
