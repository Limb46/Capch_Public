using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplayRecord : MonoBehaviour
{

    public Text firstModeRecord, secondModeRecord;

    void Start()
    {
        firstModeRecord.text = PlayerPrefs.GetInt("Score").ToString();
        secondModeRecord.text = PlayerPrefs.GetInt("ScoreSecondMode").ToString();
    }
}
