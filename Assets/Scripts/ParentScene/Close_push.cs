using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Close_push : MonoBehaviour
{
    public GameObject Panel_push;
    public Text Text_input_date;
    public Text Text_date;

    public void CloseClick()//Кнопка Войти в панели Авторизации
    {
        Text_date.text = Text_input_date.text;

        if (Panel_push != null)
        {
            bool isActive = Panel_push.activeSelf;
            Panel_push.SetActive(!isActive);
        }

    }

}
