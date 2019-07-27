using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyBott : MonoBehaviour
{
    public GameObject destroyedObject;      //  удаляемый обхект
    public GameObject holderScriptReset;    // обект на котором висит скрипт перезапуска эталона

    public void OnMouseDown()
    {
        //  удаляем объект взаимодействия
        Destroy(destroyedObject);
        //  перезапускаем скрипт генерации эталона
        ResetEralon();
    }



    public void ResetEralon()
    {
        // метод перезапуска эталона висящего на объекте holderScriptReset
        holderScriptReset.GetComponent<etalonReset>().ResetEtalonInvoke();
    }

}

