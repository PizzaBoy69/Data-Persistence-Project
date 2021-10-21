using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreTracker;

    public void Start()
    {
        bestScoreTracker.text = "Best score: " + SceneSaver.Instance.bestName + " : " + SceneSaver.Instance.highScore;
    }
}
