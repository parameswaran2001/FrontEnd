using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class PrintAllObjectNamesEditor : EditorWindow
{
    [MenuItem("Tools/Print All Object Names")]
    static void Init()
    {
        PrintAllObjectNamesEditor window = (PrintAllObjectNamesEditor)EditorWindow.GetWindow(typeof(PrintAllObjectNamesEditor));
        window.Show();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Print Object Names"))
        {
            List<string> objectNames = new List<string>();
            GetAllObjectNames(objectNames);
            objectNames.Sort();

            string filePath = EditorUtility.SaveFilePanel("Save Text File", "", "object_names", "txt");

            if (filePath != "")
            {
                StreamWriter writer = new StreamWriter(filePath);

                foreach (string name in objectNames)
                {
                    writer.WriteLine(name);
                }

                writer.Close();
            }
        }
    }

    void GetAllObjectNames(List<string> objectNames)
    {
        foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            if (go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave)
            {
                continue;
            }

            objectNames.Add(go.name);
        }
    }
}