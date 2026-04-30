using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("UI Elements")]
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject[] targetLives;
    public Text counterText;
    
    [Header("Buttons")]
    public Button winRestartButton;
    public Button winMenuButton;
    public Button loseRestartButton;
    public Button loseMenuButton;
    
    [Header("Settings")]
    public int needlesToWin = 10;
    public int maxMisses = 3;
    public GameObject popParticlePrefab;
    public float endDelay = 1.5f;
    
    [Header("References")]
    public GameObject balloon;
    public GameObject target;
    
    private int collectedNeedles = 0;
    private int missedNeedles = 0;
    private bool gameEnded = false;
    
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        UpdateUI();
        
        if (winRestartButton != null)
            winRestartButton.onClick.AddListener(RestartGame);
        if (winMenuButton != null)
            winMenuButton.onClick.AddListener(GoToMenu);
        if (loseRestartButton != null)
            loseRestartButton.onClick.AddListener(RestartGame);
        if (loseMenuButton != null)
            loseMenuButton.onClick.AddListener(GoToMenu);
    }
    
    public void CollectNeedle()
    {
        if (gameEnded) return;
        
        collectedNeedles++;
        UpdateUI();
        
        if (collectedNeedles >= needlesToWin)
        {
            gameEnded = true;
            StartCoroutine(EndGame(true));
        }
    }
    
    public void MissNeedle()
    {
        if (gameEnded) return;
        
        missedNeedles++;
        UpdateUI();
        
        if (missedNeedles >= maxMisses)
        {
            gameEnded = true;
            StartCoroutine(EndGame(false));
        }
    }
    
    void UpdateUI()
    {
        // Update counter
        counterText.text = collectedNeedles + " / " + needlesToWin;
        
        // Update target lives
        for (int i = 0; i < targetLives.Length; i++)
        {
            targetLives[i].SetActive(i < (maxMisses - missedNeedles));
        }
    }
    
    IEnumerator EndGame(bool won)
    {
        GameObject objectToDestroy = won ? balloon : target;
        
        AudioManager.instance.Play("Explosion");
        
        if (popParticlePrefab != null && objectToDestroy != null)
        {
            Instantiate(popParticlePrefab, objectToDestroy.transform.position, Quaternion.identity);
        }
        
        if (objectToDestroy != null)
            Destroy(objectToDestroy);
        
        yield return new WaitForSeconds(endDelay);
        
        if (won)
        {
            AudioManager.instance.Play("Win");
            winPanel.SetActive(true);
        }
        else
        {
            AudioManager.instance.Play("Lose");
            losePanel.SetActive(true);
        }
    }
    
    public void RestartGame()
    {
        AudioManager.instance.Play("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void GoToMenu()
    {
        AudioManager.instance.Play("ButtonClick");
        AudioManager.instance.Stop("GameMusic");
        SceneManager.LoadScene("MenuScene");
    }
}
