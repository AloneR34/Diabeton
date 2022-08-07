using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enter_from_avto : MonoBehaviour
{
    public GameObject PanelAvtorisazia;
    public GameObject PanelProfile;

    public void ButtonInAvtoToProfClick()//Кнопка Войти в панели Авторизации
    {
        if (PanelAvtorisazia != null)
        {
            bool isActive = PanelAvtorisazia.activeSelf;
            PanelAvtorisazia.SetActive(!isActive);
        }

        if (PanelProfile != null)
        {
            bool isActive = PanelProfile.activeSelf;
            PanelProfile.SetActive(!isActive);
        }
    }
}
