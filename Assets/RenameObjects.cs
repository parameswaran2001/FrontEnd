using UnityEngine;
using UnityEditor;

public class RenameObjects : EditorWindow
{
    [MenuItem("Window/Rename Objects")]
    private static void Rename()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            string oldName = obj.name;
            int index = oldName.IndexOf("A");
            if (index != -1)
            {
                string newName = "A" + oldName.Substring(index + 1) + oldName.Substring(0, index);
                obj.name = newName;
            }
        }

        Debug.Log("Objects renamed");
    }
}
