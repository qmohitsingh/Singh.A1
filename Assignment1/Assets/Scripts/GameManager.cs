using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    
    // Uncomment and assign in the Inspector if you want to use a Game Over screen
    // public GameObject gameOverScreen;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the GameManager across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one GameManager instance
        }
    }

    public void OnPlayerDeath()
    {
        EndGame();
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
        // If you have a Game Over UI, uncomment the next line to display it
        // gameOverScreen.SetActive(true);

        Time.timeScale = 0; // Pause the game, stopping all movement and actions

        // Optionally, prompt the player with a UI message offering to restart or quit
    }

    // Call this method from a UI button to restart the game
    public void RestartGame()
    {
        Time.timeScale = 1; // Ensure the game's time is running normally
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Call this method from a UI button to quit the game
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Time.timeScale = 1; // Reset time scale in case the game was paused

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Quit the game in the editor
        #else
        Application.Quit(); // Quit the game in a build
        #endif
    }
}
