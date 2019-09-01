using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setController : MonoBehaviour
{

    public InputField setOne;
    public InputField setTwo;
    public InputField setThree;
    public InputField setFour;
    public InputField setFive;
    public InputField setCoin;

    private float one, two, three, four, five;
    private int coin, record;

    private void Start()
    {
        setOne.text = PlayerPrefs.GetFloat("setOne").ToString();
        setTwo.text = PlayerPrefs.GetFloat("setTwo").ToString();
        setThree.text = PlayerPrefs.GetFloat("setThree").ToString();
        setFour.text = PlayerPrefs.GetFloat("setFour").ToString();
        setFive.text = PlayerPrefs.GetFloat("setFive").ToString();
        setCoin.text = PlayerPrefs.GetInt("coins").ToString();
    }

    public void Save()
    {
        one = float.Parse(setOne.text);
        two = float.Parse(setTwo.text);
        three = float.Parse(setThree.text);
        four = float.Parse(setFour.text);
        five = int.Parse(setFive.text);
        coin = int.Parse(setCoin.text);

        PlayerPrefs.SetFloat("setOne", one);
        PlayerPrefs.SetFloat("setTwo", two);
        PlayerPrefs.SetFloat("setThree", three);
        PlayerPrefs.SetFloat("setFour", four);
        PlayerPrefs.SetFloat("setFive", five);
        PlayerPrefs.SetInt("coins", coin);

        Application.LoadLevel("play");
    }

    public void ResetCoins()
    {
        PlayerPrefs.GetInt("coins", coin);
        coin = 0;
        PlayerPrefs.SetInt("coins", coin);
    }

    public void ResetRecord()
    {
        PlayerPrefs.GetInt("Score", record);
        record = 0;
        PlayerPrefs.SetInt("Score", record);
    }

    void Update()
    {
        
    }
}
