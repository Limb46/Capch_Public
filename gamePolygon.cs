using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePolygon : MonoBehaviour
{
    public GameObject prefab;           //  префаб создаваемого объекта
    public Transform parent;            //  родитель - игровое поле/gamePolygon
    private GameObject butt;            //  переменная для созданного объекта из префаба
    private float xCor, yCor;           //  переменные координат
    private Vector2 setPos;             //  координаты объекта
    private float[] cor = new float[3]; //  создаём массив координатных значений
    private int x, y = 0;               //  задаём переменной х значение начала массива cor
    private GameObject[] blocks;        //  массив блоков находящихся в сцене
    private int count;                  //  счёт для программы
    public Text score;                  //  счёт для скрипта
    public GameObject GamePlay;         //  прикручиваем эталон ради его скрипта



    void Start()
    {
        //  сбрасываем счётчик на 0
        count = 0;

        //  запускаем сцену
        startScen();
    }

    void startScen()
    {
        //  выполняем цикл 1-ого ряда
        genFor();

        // присваиваем переменной blocks все объекты с тегом buttPref
        blocks = GameObject.FindGameObjectsWithTag("buttPref");
        for (int li = 0; li < blocks.Length; li++)
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
        butt = Instantiate(prefab, setPos, Quaternion.identity) as GameObject;
        //  boot становится дочернеей от parent - "gamePolygon"
        butt.transform.SetParent(parent);
        //  локальному маштабу boot присвается локальный маштаб prefab
        butt.transform.localScale = prefab.transform.localScale;
        //  переменной setPos присваиваются координаты 
        setPos = butt.transform.localPosition = new Vector3(xCor, yCor, -0.5f);

    }

    // метод запускает всё заново (для дочки)
    void FixedUpdate()
    {
        blocks = GameObject.FindGameObjectsWithTag("buttPref");
        if (PlayerPrefs.GetInt("mode") == 1)
        {
            if (blocks.Length <= 0)
            {
                count++;
                score.text = count.ToString();
                startScen();
                GamePlay.GetComponent<gamePlay>().next = true;
                if (PlayerPrefs.GetInt("Score") < count)
                    PlayerPrefs.SetInt("Score", count);
            }
        }
    }
}