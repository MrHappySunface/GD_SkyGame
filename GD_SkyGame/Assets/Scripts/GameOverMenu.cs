using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameOverMenu : MonoBehaviour
{
    public GameObject GameOverMenuUI;
    public int sceneBuildIndex;

    private AudioSource audioSource;

    void Start()
    {
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
    }

    public void IsGameOver()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        audioSource.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        audioSource.Play();
        Application.Quit();
    }
}
