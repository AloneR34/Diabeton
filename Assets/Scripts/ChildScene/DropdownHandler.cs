using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{

    public GameObject Penal_result;//вывод результата
    public Text Text_result;// текст внутри поля (HE)
    public double result;// результат для формулы
    public Text result3; //Для тестирования
    public Text Text_gram;// текст внутри поля для ввода граммов
    public Text Text_result_ed;//выводимые текст результата в единицах
    public double result2;//результат в единицах
    public Dropdown dropdown;//Переменная выпадающего списка
    public int Uglivod;//Значение угливодов
    public int gram_int;// граммы для формулы

    public void DropdownItemSelected(Dropdown dropdown)
    {

        int index = dropdown.value;

        if (index == 0)
        {
            Uglivod = 20;
            Calculate_vizov();
        }

        if (index == 1)
        {
            Uglivod = 16;
            Calculate_vizov();
        }
        if (index == 2)
        {
            Uglivod = 18;
            Calculate_vizov();
        }

        if (index == 3)
        {
            Uglivod = 26;
            Calculate_vizov();
        }
        if (index == 4)
        {
            Uglivod = 22;
            Calculate_vizov();
        }
         

    }
  
    public void Calculate_vizov()//Метод, обращающийся к классу Calculate
    {
        ButtonClick();
        gram_int = int.Parse(Text_gram.text);//Переводим строковые граммы в int
        result = (Uglivod * gram_int) / 1200 * 2;

        Text_result.text = result.ToString() + " ед";//Формирования результата в строковом виде

    }

    public void ButtonClick()
    {
        if (Text_gram.text == "")
        {
            Debug.Log("Укажите колличество граммов");
        }
        else
        {
            gram_int = int.Parse(Text_gram.text);
            result = (Uglivod * gram_int) / 1200;
            Text_result.text = result.ToString() + " HE";
            if (Penal_result != null)
            {
                bool isActive = Penal_result.activeSelf;
                Penal_result.SetActive(!isActive);
            }

        }
    }
}
       


