using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyForSecondMode : MonoBehaviour
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
            setActive.GetComponent<gamePlayForSecondMode>().next = true;
            destroyedObject.SetActive(false);
            Invoke("ResetDestroyedObject", 0.8f);
            //  меняем объект взаимодействия
            destroyedObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Random.Range(0, 6).ToString());
            //  перезапускаем скрипт генерации эталона
            holderScriptReset.GetComponent<etalonReset>().ResetEtalonInvoke();
        }

        //  в противном случае
        else
        {
            setActive.GetComponent<gamePlayForSecondMode>().pressed = destroyed;
            setActive.GetComponent<gamePlayForSecondMode>().instead = etalon;

            setActive.GetComponent<gamePlayForSecondMode>().lose = true;
        }
    }

    private void ResetDestroyedObject()
    {
        destroyedObject.SetActive(true);
    }
}
