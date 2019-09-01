using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public GameObject sorryMax, sorryMin;

    public void BuyHearth()
    {
        int coin = PlayerPrefs.GetInt("coins");
        int hearth = PlayerPrefs.GetInt("hearth");
        if (coin >= 100)
        {
            if (hearth < 3)
            {
                coin -= 100;
                PlayerPrefs.SetInt("coins", coin);
                hearth++;
                PlayerPrefs.SetInt("hearth", hearth);
            }
            else
            {
                sorryMax.SetActive(true);
                Invoke("disableSorryMax", 2f);
            }
        }
        else
        {
            sorryMin.SetActive(true);
            Invoke("disableSorryMin", 2f);
        }
    }
    private void disableSorryMax()
    {
        sorryMax.SetActive(false);
    }
    private void disableSorryMin()
    {
        sorryMin.SetActive(false);
    }
}
