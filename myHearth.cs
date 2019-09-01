using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myHearth : MonoBehaviour
{
    public Text hearth;

    public void FixedUpdate()
    {
        hearth.text = PlayerPrefs.GetInt("hearth").ToString();
    }
}
