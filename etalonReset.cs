using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etalonReset : MonoBehaviour
{

    private GameObject[] blocki;
    private GameObject etalon;

    public void Start()
    {
        Invoke("ResetEtalon", 0.1f);
    }

    public void ResetEtalonInvoke()
    {
        //  вызов метода ResetEtalon с задержкой в 0,1 секунды
        Invoke("ResetEtalon", 0.1f);
        etalon = GameObject.FindGameObjectWithTag("etalon");
        etalon.GetComponent<bonusTime>().GetTrue();
    }

    public void ResetEtalon()
    {
        //  в bloki записываем все объекты с тегом buttPref
        blocki = GameObject.FindGameObjectsWithTag("buttPref");

        //  в blockiLength, типа int, записываем длинну массива blocki
        int blokiLength = blocki.Length;

        //  в массив blokiSpriteNames, типа string, записываем сточные значения blockiLength, типа string
        string[] blockiSpriteNames = new string[blokiLength];

        //  цикл: пока х < длинны массива bloki; x++
        for (int x = 0; x < blokiLength; x++)
        {
        //  blockiSpriteNames[x] принимает значение имени спрайта bliki[x] 
            blockiSpriteNames[x] = blocki[x].GetComponent<SpriteRenderer>().sprite.name;
        }

        //  в etalon записываем оъект с одноимёенным тегом
        etalon = GameObject.FindGameObjectWithTag("etalon");

        //  имени спрайта объекта etalon присваиваем рандомный спрайт с именем из массива blockiSpriteNames
        //  в диапазоне от нуля до длинны массива bloki
        etalon.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(blockiSpriteNames[Random.Range(0, blokiLength)]);

    }
}
