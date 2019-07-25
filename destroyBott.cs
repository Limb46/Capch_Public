using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyBott : MonoBehaviour
{
    public GameObject ai;
    public GameObject lol;


    //public void destroyThisObject()
    public void OnMouseDown()
    {
        Destroy(ai);

        Ebash();
        
      
        
    }



    public void Ebash()
    {
        lol.GetComponent<etalonReset>().ResetEtalon() ;
    }

}

