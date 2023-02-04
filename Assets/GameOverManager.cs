using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public void GameOver()
    {
        //show gameover
        Debug.Log("GAME OVER");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0.0f;

    }

    public void restartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
