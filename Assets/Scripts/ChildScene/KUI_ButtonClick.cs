using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KUI_ButtonClick : MonoBehaviour
{
    public GameObject Panel_KUI;
    public GameObject Panel_Profil_Child;
    public void KUIButtonClick()//Кнопка Назад в панеле регистрации
    {
            if (Panel_Profil_Child != null)
            {
                bool isActive = Panel_Profil_Child.activeSelf;
                Panel_Profil_Child.SetActive(!isActive);
            }

            if (Panel_KUI != null)
            {
                bool isActive = Panel_KUI.activeSelf;
                Panel_KUI.SetActive(!isActive);
            }
        }
    }


