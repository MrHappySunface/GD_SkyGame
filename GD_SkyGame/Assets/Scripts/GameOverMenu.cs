using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu Instance { get; private set; }
    public GameObject GameOverMenuUI;
    public TextMeshProUGUI highScoreText;
    private float highScore = 0f;
    public TextMeshProUGUI scoreText;

    public int sceneBuildIndex;
    private AudioSource audioSource;
    private CollisionReceiver collisionReceiver;

    void Awake()
    {
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
        collisionReceiver = GameObject.FindWithTag("Player").GetComponent<CollisionReceiver>();
    
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
    }

    public void IsGameOver()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;

        float currentScore = collisionReceiver.score;
        scoreText.text = "Score: " + currentScore.ToString("F0000");

        // Check if we beat the record
        if (currentScore > highScore)
        {
            highScore = currentScore;
            
            // SAVE the new high score to memory
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
        }
        highScoreText.text = "HighScore: " + highScore.ToString("F0000");
    }

    public void Restart()
    {
        StartCoroutine(RestartWithDelay());
    }

    private IEnumerator RestartWithDelay()
    {
        audioSource.Play();
        yield return new WaitForSecondsRealtime(.2f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        StartCoroutine(QuitWithDelay());
    }

    private IEnumerator QuitWithDelay()
    {
        audioSource.Play();
        yield return new WaitForSecondsRealtime(.2f);
        Application.Quit();
    }
}
