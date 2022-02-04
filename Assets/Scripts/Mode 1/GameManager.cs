using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int count = 0;
    public Text countText;
    [SerializeField] Text highscoreText;
    [SerializeField] GameObject gameOverScreen;
    bool gameIsOver = false;
    public bool GameIsOver
    {
        get
        {
            return gameIsOver;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(1);
        else if (Input.GetKeyDown(KeyCode.Q))
            SceneManager.LoadScene(0);
    }

    // increase score
    public void IncreaseCount()
    {
        count++;
        countText.text = "Fruit Collected " + count;
    }

    // move game state to game over and display game over screen
    public void GameOver()
    {
        gameIsOver = true;
        countText.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);


        if (count > MainManager.Instance.bestScore1)
        {
            highscoreText.gameObject.SetActive(true);

            MainManager.Instance.bestScore1 = count;
            MainManager.Instance.highScoreName1 = MainManager.Instance.userName;
            MainManager.Instance.SaveScore1();
        }
    }
}
