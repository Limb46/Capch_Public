using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePlay : MonoBehaviour
{

    private GameObject[] blocki;
   
    public GameObject etalon;

    void Start()
    {
        
        StartCoroutine(Example());

        
    }

    IEnumerator Example()
    {


        yield return new WaitForSeconds(0.1f);
        blocki = GameObject.FindGameObjectsWithTag("bottPref");

        etalon.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(blocki[Random.Range(0, blocki.Length)].GetComponent<SpriteRenderer>().sprite.name);
    }

    public void ResetEtalon()
    {
        StartCoroutine(Example());
    }


    void FixedUpdate()
    {
        
    }


    void Update()
    {
        
    }


}
