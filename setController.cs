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

    private float one, two, three, four, five;

    private void Start()
    {
        setOne.text = PlayerPrefs.GetFloat("setOne").ToString();
        setTwo.text = PlayerPrefs.GetFloat("setTwo").ToString();
        setThree.text = PlayerPrefs.GetFloat("setThree").ToString();
        setFour.text = PlayerPrefs.GetFloat("setFour").ToString();
        setFive.text = PlayerPrefs.GetFloat("setFive").ToString();
    }

    public void Save()
    {
        one = float.Parse(setOne.text);
        two = float.Parse(setTwo.text);
        three = float.Parse(setThree.text);
        four = float.Parse(setFour.text);
        five = int.Parse(setFive.text);

        PlayerPrefs.SetFloat("setOne", one);
        PlayerPrefs.SetFloat("setTwo", two);
        PlayerPrefs.SetFloat("setThree", three);
        PlayerPrefs.SetFloat("setFour", four);
        PlayerPrefs.SetFloat("setFive", five);

        Application.LoadLevel("play");
    }

    void Update()
    {
        
    }
}
