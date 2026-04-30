using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;
    public Button exitButton;
    
    void Start()
    {
        // Play menu music
        AudioManager.instance.Play("MenuMusic");
        
        // Add listeners to buttons
        if (startButton != null)
            startButton.onClick.AddListener(StartGame);
            
        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
    }
    
    public void StartGame()
    {
        AudioManager.instance.Play("ButtonClick");
        AudioManager.instance.Stop("MenuMusic");
        SceneManager.LoadScene("GameScene");
    }
    
    public void ExitGame()
    {
        AudioManager.instance.Play("ButtonClick");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
