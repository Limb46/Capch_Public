using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusTime : MonoBehaviour
{
    public GameObject scriptHolder;
    private int speadScore;
    private float[] speadTimerStart = new float[10];
    private bool[] speadControl = new bool[10];
    private float timer;
    private int[] tq = new int[10];
    public bool lose;
    private float spead;

    private void Start()
    {
        spead = PlayerPrefs.GetFloat("setFour");
    }

    public void GetTrue()
    {
        speadScore++;
        speadTimerStart[speadScore] = timer;
        if (speadScore == 9 || lose)
        {
            lose = false;
            for (int u = 0; u < 10; u++)
            {
                speadTimerStart[u] = 0;
                tq[u] = 0;
            }
            speadScore = 0;
        } 
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        int w = 1;
        for (int q = 0; q < 9; q++, w++)
        {
            speadControl[q] = speadTimerStart[w] - speadTimerStart[q] <= spead && speadTimerStart[w] - speadTimerStart[q] > 0;

            if (speadControl[q] && tq[q] < 1)
            {
                scriptHolder.GetComponent<gamePlay>().bonus = true;
                tq[q]++;
            }
        }
    }
}