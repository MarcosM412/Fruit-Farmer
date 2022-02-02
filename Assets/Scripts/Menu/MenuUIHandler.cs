using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] InputField inputName;
    [SerializeField] Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.LoadScore();

        if (MainManager.Instance.bestScore > 0)
        {
            bestScoreText.text = "Best Score: " + MainManager.Instance.highScoreName + ": " + MainManager.Instance.bestScore;
        }
    }

    public void StartNew()
    {
        MainManager.Instance.userName = inputName.text;
        Debug.Log("userName is " + MainManager.Instance.userName);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        MainManager.Instance.SaveScore();
    }
}
