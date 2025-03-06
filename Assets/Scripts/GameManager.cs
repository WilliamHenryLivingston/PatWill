using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerInput playerInput;

    public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }
    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void DisablePlayerMovement()
    {
        playerInput.gameObject.SetActive(false);
    }

    public void EnablePlayerMovement()
    {
        playerInput.gameObject.SetActive(true);
    }


}
