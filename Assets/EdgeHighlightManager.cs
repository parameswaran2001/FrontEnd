using UnityEngine;

public class EdgeHighlightManager : MonoBehaviour
{
    public Material edgeMaterial; // The material used for highlighting the edges
    public GameObject[] cubes; // Array to store references to the cubes

    void Start()
    {
        cubes = FindAllCubes();
        foreach (GameObject cube in cubes)
        {
            AddMeshFilter(cube);
            ApplyEdgeHighlight(cube);
        }
    }

    GameObject[] FindAllCubes()
    {
        MeshFilter[] meshFilters = FindObjectsOfType<MeshFilter>();
        GameObject[] foundCubes = new GameObject[meshFilters.Length];
        int cubeCount = 0;

        foreach (MeshFilter meshFilter in meshFilters)
        {
            if (meshFilter.gameObject.CompareTag("Cube"))
            {
                foundCubes[cubeCount] = meshFilter.gameObject;
                cubeCount++;
            }
        }

        // Resize the array to fit only the found cubes
        System.Array.Resize(ref foundCubes, cubeCount);

        return foundCubes;
    }

    void AddMeshFilter(GameObject cube)
    {
        if (cube.GetComponent<MeshFilter>() == null)
        {
            cube.AddComponent<MeshFilter>();
        }
    }

    void ApplyEdgeHighlight(GameObject cube)
    {
        MeshFilter meshFilter = cube.GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = cube.GetComponent<MeshRenderer>();

        // Create a new mesh with only the edges
        Mesh newMesh = meshFilter.sharedMesh;
        newMesh.SetIndices(newMesh.GetIndices(0), MeshTopology.Lines, 0);

        // Assign the edge material to the mesh renderer
        meshRenderer.sharedMaterial = edgeMaterial;
        meshRenderer.receiveShadows = false;
        meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }
}
