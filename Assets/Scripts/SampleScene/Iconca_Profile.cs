using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Iconca_Profile : MonoBehaviour
{
    public GameObject PanelAvtorizasia;


    public void OpenPenal()
    {
        if (PanelAvtorizasia != null)
        {
            bool isActive = PanelAvtorizasia.activeSelf;
            PanelAvtorizasia.SetActive(!isActive);
        }

    }
}
