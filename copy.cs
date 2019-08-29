using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copy : MonoBehaviour
{
    public GameObject prefab;   //  префаб создаваемого объекта
    public Transform parent;    //  родитель - игровое поле/gamePolygon
    private GameObject butt;    //  переменная для созданного объекта из префаба
    private float xCor, yCor;   //  переменные координат
    private Vector2 setPos;     //   координаты объекта
    private float[] cor = new float[3]; //  создаём массив координатных значений
    private int x = 0;          //  задаём переменной х значение начала массива cor

    public GameObject[] blocks;
    public Sprite oneS;


    void Start()
    {
        //  присваиваем значения в массиве
        cor[0] = -330f;
        cor[1] = 0;
        cor[2] = 330f;

        //  выполняем цикл 1-ого ряда
        for (int q = 1; q <= 3; q++)
        {
            xCor = cor[x];  //  координаты xCor из массива cor
            yCor = cor[2];  //  координаты yCor из массива cor
            generate();     //  вызов метода генерации объекта
            x++;            //  к значению х из массива cor прибавляем единицу
            new WaitForSecondsRealtime(10);
        }
        x = 0;          //  обнуляем х для следующего цикла

        //  выполняем цикл 2-ого ряда
        for (int q = 4; q <= 6; q++)
        {
            xCor = cor[x];
            yCor = cor[1];
            generate();
            x++;
        }
        x = 0;

        //  выполняем цикл 3-ого ряда
        for (int q = 7; q <= 9; q++)
        {
            xCor = cor[x];
            yCor = cor[0];
            generate();
            x++;
        }
        x = 0;

        // присваиваем переменной blocks все объекты с тегом buttPref
        blocks = GameObject.FindGameObjectsWithTag("buttPref");
        for (int li = 0; li < blocks.Length; li++)
        {
            blocks[li].name = ("" + li);     //  переименуем все найденные объекты
                                             //blocks[li].GetComponent<SpriteRenderer>().sprite = ;

        }
        blocks[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("figures");
        blocks[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("figures_1");


        //var zalupa = blocks[0].GetComponent<Image>;

    }

    //  метод генерации объекта из префаба и первичная его настройка
    void generate()
    {
        //  boot присваеваем вызов объекта prefab
        butt = Instantiate(prefab, setPos, Quaternion.identity) as GameObject;
        //  boot становится дочернеей от parent - "gamePolygon"
        butt.transform.SetParent(parent);
        //  локальному маштабу boot присвается локальный маштаб prefab
        butt.transform.localScale = prefab.transform.localScale;
        //  переменной setPos присваиваются координаты 
        setPos = butt.transform.localPosition = new Vector2(xCor, yCor);

    }

    // Update is called once per frame
    void Update()
    {

    }
}