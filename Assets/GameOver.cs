using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;

    public Text ScoreText;

    public static bool IsGameOver;

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        IsGameOver = false;

        Player.PlayerDeath += Player_PlayerDeath;

        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        Player.PlayerDeath -= Player_PlayerDeath;
    }

    private void Player_PlayerDeath()
    {
        ScoreText.text = $"{ScoreManager.WaveCount} - {ScoreManager.Score}"
            + "\n" + $"{ScoreManager.HighWaveCount} - {ScoreManager.HighScore}";

        GameOverPanel.SetActive(true);
        IsGameOver = true;

        Time.timeScale = 0;
    }

    public void RetryGame()
    {
        ScoreManager.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
