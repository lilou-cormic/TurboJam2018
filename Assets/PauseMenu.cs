using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    public static bool GameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver.IsGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            PausePanel.SetActive(!PausePanel.activeSelf);

            GameIsPaused = PausePanel.activeSelf;

            if (GameIsPaused)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }

    public void Continue()
    {
        if (GameOver.IsGameOver)
            return;

        PausePanel.SetActive(false);

        GameIsPaused = PausePanel.activeSelf;

        Time.timeScale = 1;
    }
}
