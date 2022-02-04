using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
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

    private float timer = 0;
    private float waitTime = 60;
    [SerializeField] Text timerText;

    Counter counter;

    private void Start()
    {
        counter = GameObject.Find("Red Player Box").GetComponent<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsOver)
            Timer();

        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(1);
        else if (Input.GetKeyDown(KeyCode.Q))
            SceneManager.LoadScene(0);
    }

    // move game state to game over and display game over screen
    public void GameOver()
    {
        gameIsOver = true;
        countText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);


        if (counter.Count > MainManager.Instance.bestScore2)
        {
            highscoreText.gameObject.SetActive(true);

            MainManager.Instance.bestScore2 = counter.Count;
            MainManager.Instance.highScoreName2 = MainManager.Instance.userName;
            MainManager.Instance.SaveScore2();
        }
    }

    void Timer()
    {
        if (timer < waitTime)
        {
            timer += Time.deltaTime;
            timerText.text = "Timer: " + Mathf.Round(timer);
        }
        else
            GameOver();
    }
}
