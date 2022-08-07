using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Preparing : MonoBehaviour
{
    public int gram_int;// граммы для формулы
    //DropdownHandler uglivod = new DropdownItemSelected();
    //public DropdownHandler uglivod;
    public int uglivod;//угливоды в определенных продуктах

    public GameObject Penal_result;//вывод результата
    public Text Text_result;// текст внутри поля (HE)
    public double result;// результат для формулы
    public Text result3; //Для тестирования
    public Text Text_gram;// текст внутри поля для ввода граммов
    public Text Text_result_ed;//выводимые текст результата в единицах
    public double result2;//результат в единицах

    public void Calculate_HE()
    {

        if (Text_gram.text == "")
        {
            Debug.Log("Укажите колличество граммов");
        }
        else
        {
            if (Penal_result != null)
            {
                bool isActive = Penal_result.activeSelf;
                Penal_result.SetActive(!isActive);
            }

        }
        
        
            gram_int = int.Parse(Text_gram.text);

            
            result2 = Calculate_He.Calculate(uglivod, gram_int) * 2;//2-KUI меняется по БД
            Text_result.text = result2.ToString() + " ед";
            Text_result_ed.text = Calculate_He.Calculate(uglivod, gram_int).ToString() + " ед";
            result3.text = gram_int.ToString() + " " + uglivod.ToString();
        
    }
}
 
    
    
 

    

