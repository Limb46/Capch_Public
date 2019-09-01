using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houMachHearth : MonoBehaviour
{
    public GameObject one, two, three;

    void FixedUpdate()
    {
        int myHearth = PlayerPrefs.GetInt("hearth");

        if (myHearth == 3)
        {
            one.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOn");
            two.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOn");
            three.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOn");
        }
        if (myHearth == 2)
        {
            one.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOn");
            two.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOn");
            three.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOff");
        }
        if (myHearth == 1)
        {
            one.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOn");
            two.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOff");
            three.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOff");
        }
        if (myHearth == 0)
        {
            one.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOff");
            two.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOff");
            three.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hearthOff");
        }
    }
}
