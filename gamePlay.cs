using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePlay : MonoBehaviour
{
    public GameObject etalon;
    //  таймер
    public Text Timer;
    public Text BonusText;
    public GameObject Bonus;
    public Image timerImage;

    //  проигрыш
    public GameObject pLose;
    public GameObject gamePole;
    public bool next, lose, bonus;

    private int numberOfLevels;

    private bool[] conditions = new bool[9];
    private float[] tOne = new float[9];
    private float[] tTwo = new float[9];


    public void Start()
    {
        BonusText.text = ("+ " + PlayerPrefs.GetFloat("setThree").ToString());
        float getOne = PlayerPrefs.GetFloat("setOne");
        float getTwo = PlayerPrefs.GetFloat("setTwo");
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
        StartTimer();

        int e = 2;
        int r = 4;
        conditions[0] = numberOfLevels <= 2;
        for (int w = 1; w < 9; w++, e = e + 2, r = r += 2)
        {
            conditions[w] = numberOfLevels > e && numberOfLevels <= r;
        }
    }

    public void StartTimer()
    {


        for (int c = 0; c < 9; c++)
        {
            if (conditions[c])
            {
                if (next)
                {
                    next = false;
                    numberOfLevels++;
                    tOne[c] = tTwo[c];
                }
                tOne[c] -= Time.deltaTime;
                    if (bonus)
                    {
                   // Debug.Log("HOROSHO");
                        tOne[c] += PlayerPrefs.GetFloat("setThree");
                        bonus = false;
                        StartCoroutine("BonusView");
                    }
                Timer.text = tOne[c].ToString("0.00");
                timerImage.fillAmount = (tOne[c] * (100 / tTwo[c])) / 100;

                if (lose || tOne[c] <= 0)
                {
                    GamerLose();
                    etalon.GetComponent<bonusTime>().lose = true;
                }
            }
        }


    }

    public void GamerLose()
    {
        pLose.SetActive(true);
        gamePole.SetActive(false);
    }

    IEnumerator BonusView()
    {
        Bonus.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Bonus.SetActive(false);
        yield return null;
    }

}
