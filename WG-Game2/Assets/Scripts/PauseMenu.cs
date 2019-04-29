using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public GameObject restUI;
    public static bool GameIsPaused = false;
    public Text pauseScoreText;

    private void Update()
    {
        pauseScoreText.text = "Your current score: " + GameObject.FindGameObjectWithTag("ScoreCount").GetComponent<ScoreCount>().score.ToString();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        restUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameObject.FindGameObjectWithTag("Shooter").GetComponent<RocketShooter>().enabled = false;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        restUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameObject.FindGameObjectWithTag("Shooter").GetComponent<RocketShooter>().enabled = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        pauseMenuUI.SetActive(false);
        restUI.SetActive(true);
        Time.timeScale = 1f;
    }

}
