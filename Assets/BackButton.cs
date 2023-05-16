using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public string previousSceneName; // The name of the previous scene

    void Update()
    {
        // Check if the "Back" button or the "Escape" key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadPreviousScene();
        }
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(previousSceneName); // Load the previous scene
    }
}
