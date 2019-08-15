using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplayRecord : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Score").ToString();
    }
}
