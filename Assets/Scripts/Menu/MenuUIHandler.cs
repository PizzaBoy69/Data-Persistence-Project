using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputName;
    public TextMeshProUGUI bestScoreTracker;

    private void Start()
    {
        inputName = transform.Find("Enter Name").GetComponent<TMP_InputField>();
        bestScoreTracker.text = "Best score: " + SceneSaver.Instance.bestName + " : " + SceneSaver.Instance.highScore;
    }

    public void StartGame()
    {
        SceneSaver.Instance.playerName = inputName.text;
        Debug.Log("Name " + SceneSaver.Instance.playerName);
        SceneSaver.Instance.LoadRecord();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SceneSaver.Instance.SaveRecord();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit;
#endif
    }   
}

