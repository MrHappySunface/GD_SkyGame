using UnityEngine;
using TMPro;

public class CollisionReceiver : MonoBehaviour
{
    float score = 0;
    public TextMeshProUGUI gameScoreText;
    private AudioSource playerAudio;

    private Health healthScript;
    public GameOverMenu gameoverMenu;

    private void Awake()
    {
        healthScript = GetComponent<Health>();
        playerAudio = GetComponent<AudioSource>();
    }
    void increase_score (Vector2 range)
    {

        float randomVal = Random.Range((int)range.x, (int)range.y);

        score += randomVal;

        if (gameScoreText != null)
        {
            gameScoreText.text = score.ToString("F0");
        }
        Debug.Log("Score is " + score);
    }

    void Update()
    {
    if (healthScript != null && healthScript.Hp <= 0) 
        {
            playerAudio.Stop();

            if (gameoverMenu != null)
                gameoverMenu.IsGameOver();
        }
    }
}