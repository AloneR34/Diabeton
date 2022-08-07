  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public GameObject Panel_result;
    public Text Text_result;//Text
    public Text Text_CDI;//Text
    public GameObject Toggle_ultra;
    public GameObject Toggle_short;
    public int koefisient=0;//Коефициент 100 или 83
    public double result=0.0;//Результирующая переменная
    public int CDI; //Для конвертации в int из InputField



    public void ButtonCalculate()
    {
            if (Panel_result != null)
        {
            bool isActive = Panel_result.activeSelf;
             Panel_result.SetActive(!isActive);
        }

        CDI = int.Parse(Text_CDI.text);

        if (Toggle_ultra != null)
        {
            {
                koefisient = 83;
            }
        if (Toggle_short != null)
            {
                koefisient = 100;
            }
        else
            {
                Text_result.text = "Ошибка коеф";
            }
        }
        else
        {
            if (Text_CDI.text == null)
            {
                Text_result.text = "Ошибка CDI";
            }
        }
        if (Text_CDI.text != null && koefisient!=0)
            { 
                Text_result.text = Calculate.CalculateKUI(koefisient, CDI).ToString();// Вызов функции 
            }
    }
}
