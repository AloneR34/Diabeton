using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    public GameObject Panel_Profil;
    public GameObject Panel_food;

    public void foodClick()
    {
        if (Panel_Profil != null)
        {
            bool isActive = Panel_Profil.activeSelf;
            Panel_Profil.SetActive(!isActive);
        }
        if (Panel_food != null)
        {
            bool isActive = Panel_food.activeSelf;
            Panel_food.SetActive(!isActive);
        }
    }
}
