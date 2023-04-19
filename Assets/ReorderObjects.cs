using UnityEngine;

public class ReorderObjects : MonoBehaviour
{
    private void Start()
    {
        // Get all root game objects in the scene
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

        // Iterate over each root object
        foreach (GameObject rootObject in rootObjects)
        {
            // Iterate over each child object of the root object
            int childCount = rootObject.transform.childCount;
            GameObject[] children = new GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                children[i] = rootObject.transform.GetChild(i).gameObject;
            }

            System.Array.Sort(children, CompareGameObjectNames);

            for (int i = 0; i < childCount; i++)
            {
                children[i].transform.SetSiblingIndex(i);
            }
        }
    }

    private int CompareGameObjectNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }
}
