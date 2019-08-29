using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyButt : MonoBehaviour
{
    public GameObject destroyedObject;      //  удаляемый обхект
    public GameObject holderScriptReset;    // обект на котором висит скрипт перезапуска эталона
    private GameObject setActive;

    private void Start()
    {
        setActive = GameObject.Find("Etalon");
    }

    public void OnMouseDown()
    {
        //  переменной etalon присваиваем имя спрайта одноимённого объекта
        string etalon = GameObject.FindGameObjectWithTag("etalon").GetComponent<SpriteRenderer>().sprite.name;

        string destroyed = destroyedObject.GetComponent<SpriteRenderer>().sprite.name;

        //  если имя спрайта эталона = имени спрайта нажатоко объекта то:
        if (etalon == destroyed)
        {
            //  удаляем объект взаимодействия
            Destroy(destroyedObject);
            //  перезапускаем скрипт генерации эталона
            holderScriptReset.GetComponent<etalonReset>().ResetEtalonInvoke();
        }

        //  в противном случае
        else
        {
            setActive.GetComponent<gamePlay>().pressed = destroyed;
            setActive.GetComponent<gamePlay>().instead = etalon;

            setActive.GetComponent<gamePlay>().lose = true;
        }
    }
}

