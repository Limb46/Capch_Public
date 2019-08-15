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

    private float one, two, three, four;

    private void Start()
    {
        setOne.text = PlayerPrefs.GetFloat("setOne").ToString();
        setTwo.text = PlayerPrefs.GetFloat("setTwo").ToString();
        setThree.text = PlayerPrefs.GetFloat("setThree").ToString();
        setFour.text = PlayerPrefs.GetFloat("setFour").ToString();
    }

    public void Save()
    {
        one = float.Parse(setOne.text);
        two = float.Parse(setTwo.text);
        three = float.Parse(setThree.text);
        four = float.Parse(setFour.text);

        PlayerPrefs.SetFloat("setOne", one);
        PlayerPrefs.SetFloat("setTwo", two);
        PlayerPrefs.SetFloat("setThree", three);
        PlayerPrefs.SetFloat("setFour", four);

        Application.LoadLevel("play");
    }

    void Update()
    {
        
    }
}
