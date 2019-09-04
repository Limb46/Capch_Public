using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{

    public GameObject buyHearth;

    void OnMouseUpAsButton()
    {


        switch (gameObject.name)
        {
            case "Replay":
                Application.LoadLevel("firstMode");
                break;
            case "ReplaySecondMode":
                Application.LoadLevel("secondMode");
                break;
            case "Play":
                Application.LoadLevel("firstMode");
                PlayerPrefs.SetInt("mode", 1);
                break;
            case "PlayTwo":
                Application.LoadLevel("secondMode");
                PlayerPrefs.SetInt("mode", 2);
                break;
            case "Home":
                Application.LoadLevel("play");
                break;
            case "Settings":
                Application.LoadLevel("settings");
                break;
            case "Shop":
                Application.LoadLevel("shop");
                break;
            case "back":
                Application.LoadLevel("play");
                break;
            case "Buy Hearth":
                buyHearth.GetComponent<shop>().BuyHearth();
                break;

        }
    }
}
