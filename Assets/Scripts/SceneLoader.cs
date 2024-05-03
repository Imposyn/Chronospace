using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Function to load the "Game" scene
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}