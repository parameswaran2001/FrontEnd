using UnityEngine;

public class QuitButtonHandler : MonoBehaviour
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