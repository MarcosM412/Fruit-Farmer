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
    [SerializeField] Text mode1Text;
    [SerializeField] Text mode2Text;


    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.LoadScore();

        if (MainManager.Instance.bestScore1 > 0)
        {
            mode1Text.text = "Mode 1: " + MainManager.Instance.highScoreName1 + ": " + MainManager.Instance.bestScore1;
        }
        if (MainManager.Instance.bestScore2 > 0)
        {
            mode2Text.text = "Mode 2: " + MainManager.Instance.highScoreName2 + ": " + MainManager.Instance.bestScore2;
        }
    }

    public void StartNew(int scene)
    {
        MainManager.Instance.userName = inputName.text;
        Debug.Log("userName is " + MainManager.Instance.userName);
        SceneManager.LoadScene(scene);
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
