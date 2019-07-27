using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePolygon : MonoBehaviour
{
    public GameObject prefab;           //  префаб создаваемого объекта
    public Transform parent;            //  родитель - игровое поле/gamePolygon
    private GameObject bott;            //  переменная для созданного объекта из префаба
    private float xCor, yCor;           //  переменные координат
    private Vector2 setPos;             //   координаты объекта
    private float[] cor = new float[3]; //  создаём массив координатных значений
    private int x, y = 0;               //  задаём переменной х значение начала массива cor
    private GameObject[] blocks;        //  массив блоков находящихся в сцене


    void Start()
    {
        //  выполняем цикл 1-ого ряда
        genFor();

        // присваиваем переменной blocks все объекты с тегом bottPref
        blocks = GameObject.FindGameObjectsWithTag("bottPref");
        for(int li = 0; li < blocks.Length; li++)
        {
           blocks[li].name = (li.ToString());     //  переименуем все найденные объекты
                                           //blocks[li].GetComponent<SpriteRenderer>().sprite = ;
            blocks[li].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Random.Range(0, 6).ToString());
        }

    }

    void genFor()
    {
        for (int q = 1; q <= 9; q++)
        {
            cor = new float[] { -330f, 0, 330 };    //  присваиваем значения в массиве  
            if (q <= 3) { y = 2; }
            if (q >= 4 && q <= 6) { y = 1; }
            if (q >= 7 && q <= 9) { y = 0; }
            if (x >= 3) { x = 0; }

            xCor = cor[x];  //  координаты xCor из массива cor
            yCor = cor[y];  //  координаты yCor из массива cor
            generate();     //  вызов метода генерации объекта
            x++;            //  к значению х из массива cor прибавляем единицу
        }
    }

    //  метод генерации объекта из префаба и первичная его настройка
    void generate() 
    {
        //  boot присваеваем вызов объекта prefab
        bott = Instantiate(prefab, setPos, Quaternion.identity) as GameObject;
        //  boot становится дочернеей от parent - "gamePolygon"
        bott.transform.SetParent(parent);
        //  локальному маштабу boot присвается локальный маштаб prefab
        bott.transform.localScale = prefab.transform.localScale;
        //  переменной setPos присваиваются координаты 
        setPos = bott.transform.localPosition = new Vector3(xCor, yCor, -0.5f);

    }

    // метод запускает всё заново (для дочки)
    void FixedUpdate()
    {
        blocks = GameObject.FindGameObjectsWithTag("bottPref");
        if (blocks.Length <= 0)
        {
            Start();
        }
    }
}