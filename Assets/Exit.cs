using UnityEngine;

public class Exit : MonoBehaviour
{
    // Quit the game when the quit button is clicked
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}