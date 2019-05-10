using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text ScoreText;
    public Text HighScoreText;

    public Text WaveCountText;
    public Text HighWaveCountText;

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ScoreManager.Score.ToString();
        HighScoreText.text = ScoreManager.HighScore.ToString();

        WaveCountText.text = ScoreManager.WaveCount.ToString();
        HighWaveCountText.text = ScoreManager.HighWaveCount.ToString();
    }
}
