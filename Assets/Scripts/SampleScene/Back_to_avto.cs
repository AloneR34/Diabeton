using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back_to_avto : MonoBehaviour
{
    public GameObject PanelAvtorisazia;
    public GameObject PanelRegistrasia;
    public void BackButtonClick()//Кнопка Назад в панеле регистрации
    {
        if (PanelRegistrasia != null)
        {
            bool isActive = PanelRegistrasia.activeSelf;
            PanelRegistrasia.SetActive(!isActive);
        }

        if (PanelAvtorisazia != null)
        {
            bool isActive = PanelAvtorisazia.activeSelf;
            PanelAvtorisazia.SetActive(!isActive);
        }
    }
}
