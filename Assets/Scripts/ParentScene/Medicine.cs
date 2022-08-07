using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Medicine : MonoBehaviour
{
        public GameObject Panel_Profil;
        public GameObject Panel_Medicine;

    public void medicineClick()
    { 
        if (Panel_Profil != null)
        {
            bool isActive = Panel_Profil.activeSelf;
            Panel_Profil.SetActive(!isActive);
        }
        if (Panel_Medicine != null)
        {
            bool isActive = Panel_Medicine.activeSelf;
            Panel_Medicine.SetActive(!isActive);
        }
    }
}
