using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myCoins : MonoBehaviour
{
    public Text coins;

    public void FixedUpdate()
    {
        coins.text = PlayerPrefs.GetInt("coins").ToString();
    }
}
