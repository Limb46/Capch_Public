﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePlay : MonoBehaviour
{
    public GameObject etalon;
    //  таймер
    public Text Timer, BonusText, Level;
    public GameObject Bonus;
    public Image timerImage;

    //  проигрыш
    public GameObject pLose, gamePole, pressing, timeOut, press, inst;

    public bool next, lose, bonus, checkIt;

    private int numberOfLevels;

    private bool[] conditions = new bool[9];
    private float[] tOne = new float[9];
    private float[] tTwo = new float[9];

    private float getThree;
    private int setter, check;

    public string pressed, instead;

    private int coin;

    public void Start()
    {
        BonusText.text = ("+ " + PlayerPrefs.GetFloat("setThree").ToString());
        float getOne = PlayerPrefs.GetFloat("setOne");
        float getTwo = PlayerPrefs.GetFloat("setTwo");
        getThree = PlayerPrefs.GetFloat("setFive");

        //coin = PlayerPrefs.GetInt("coins");
        for (int q = 0; q < 9; q++, getOne = getOne - getTwo)
        {
            tOne[q] = getOne;
        }
        numberOfLevels = 0;

        next = false;
        lose = false;
        bonus = false;


        for(int qw = 0; qw < 9; qw++)
        {
            tTwo[qw] = tOne[qw];
        }
    }


    public void FixedUpdate()
    {
        Actions();
    }


    public void GamerLosePress()
    {
        press.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(pressed);
        inst.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(instead);
        GamerLose();
        pressing.SetActive(true);
    }
    public void GamerLoseTime()
    {
        GamerLose();
        timeOut.SetActive(true);
    }
    public void GamerLose()
    {
        pLose.SetActive(true);
        gamePole.SetActive(false);
        etalon.GetComponent<bonusTime>().lose = true;
        Level.text = numberOfLevels.ToString();
    }


    public void Actions()
    {
        if (next)
        {
            AddCoin();
            check++;
            if (check == 2 && checkIt == false)
            {
                setter++;
                check = 0;
            }
            next = false;
            numberOfLevels++;
            if (setter >= getThree)
            {
                checkIt = true;
            }
            tOne[setter] = tTwo[setter];
        }
        
     tOne[setter] -= Time.deltaTime;
        if (bonus)
        {
            tOne[setter] += PlayerPrefs.GetFloat("setThree");
            bonus = false;
            StartCoroutine("BonusView");
        }
        int hearth = PlayerPrefs.GetInt("hearth");
        if (lose)
        {
            if (hearth == 0)
            {
                GamerLosePress();
            }
            if (hearth != 0)
            {
                hearth -= 1;
                PlayerPrefs.SetInt("hearth", hearth);
                lose = false;
            }
        }
        if (tOne[setter] <= 0)
        {
            GamerLoseTime();
        }
     Timer.text = tOne[setter].ToString("0.00");
     timerImage.fillAmount = (tOne[setter] * (100 / tTwo[setter])) / 100;
    }

    private void AddCoin()
    {
        coin = PlayerPrefs.GetInt("coins");
        coin += 10;
        PlayerPrefs.SetInt("coins", coin);
    }

    IEnumerator BonusView()
    {
        Bonus.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Bonus.SetActive(false);
        yield return null;
    }
}
