using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class food_panel_open : MonoBehaviour
{
    public GameObject Food_panel;
    public GameObject Kashi_panel;
    public GameObject Panel_Profil_Child;
    public void open_food_panel()
    {
        if (Food_panel != null)
        {
            bool isActive = Food_panel.activeSelf;
            Food_panel.SetActive(!isActive);
        }
        if (Kashi_panel != null)
        {
            bool isActive = Kashi_panel.activeSelf;
            Kashi_panel.SetActive(!isActive);
        }
        if (Panel_Profil_Child != null)
        {
            bool isActive = Panel_Profil_Child.activeSelf;
            Panel_Profil_Child.SetActive(!isActive);
        }
    }


}
