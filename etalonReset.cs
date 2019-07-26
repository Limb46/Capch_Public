using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etalonReset : MonoBehaviour
{

    private GameObject[] blocki;
    public GameObject etalon;
    private int colVo;

    void Start()
    {

       


    }


    //for (int li = 0; li < blocki.Length; li++)
    //{
    //blocks[li].name = ("ada" + li);     //  переименуем все найденные объекты
    //blocks[li].GetComponent<SpriteRenderer>().sprite = ;
    //blocks[li].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("" + Random.Range(0, 6) + "");
    //}
    //}


    void FixedUpdate()
    {
        
    }



    //public void OnMouseUpAsButton()
    //{
    //    ResetEtalon();
    //}

    public void ResetEtalonInvoke()
    {
        Invoke("ResetEtalon", 0.1f);
    }


        public void ResetEtalon()
    {

        blocki = GameObject.FindGameObjectsWithTag("bottPref");
        Debug.Log("Dlinna massiva = " + blocki.Length);

        int xer = blocki.Length;
        Debug.Log("Dlina massiva " + xer);

        string[] imena = new string[xer];
        Debug.Log("HHHHHHHHHHHHHHHHHHHHHHH  " + imena.Length);
        for (int x = 0; x < xer; x++)
        {
            imena[x] = blocki[x].GetComponent<SpriteRenderer>().sprite.name;
            Debug.Log("blok = " + blocki[x].name + " || imena = " + imena[x] );
        }

        

        //===========================================================================================================

        etalon = GameObject.FindGameObjectWithTag("etalon");
        colVo = blocki.Length;
        Debug.Log("Peremennayz colVo = " + (colVo - 1));
        Debug.Log("Ostalos = " + xer);
        etalon.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imena[Random.Range(0, xer)]);
       
    }


    


    void Update()
    {

    }


}
