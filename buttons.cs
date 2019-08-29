using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
    void OnMouseUpAsButton()
    {


        switch (gameObject.name)
        {
            case "Replay":
                Application.LoadLevel("SampleScene");
                break;
            case "Play":
                Application.LoadLevel("SampleScene");
                break;
            case "Home":
                Application.LoadLevel("play");
                break;
            case "Settings":
                Application.LoadLevel("settings");
                break;
        }
    }
}
