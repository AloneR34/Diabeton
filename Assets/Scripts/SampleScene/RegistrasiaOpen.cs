using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistrasiaOpen : MonoBehaviour
{
    public GameObject PanelAvtorisazia;
    public GameObject PanelRegistrasia;
    // Start is called before the first frame update
    public void RegistrasiaClick()// Из панель Авторизации перейти в регистрацию
        {
            if (PanelAvtorisazia != null)
            {
                bool isActive = PanelAvtorisazia.activeSelf;
                PanelAvtorisazia.SetActive(!isActive);
            }

            if (PanelRegistrasia != null)
            {
                bool isActive = PanelRegistrasia.activeSelf;
                PanelRegistrasia.SetActive(!isActive);
            }
        }
    }
