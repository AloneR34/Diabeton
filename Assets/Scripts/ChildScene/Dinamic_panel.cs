using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dinamic_panel : MonoBehaviour
{
    public GameObject Panel_Kashi;
    public void OpenPenal()
    {
        if (Panel_Kashi != null)
        {
            bool isActive = Panel_Kashi.activeSelf;
            Panel_Kashi.SetActive(!isActive);
        }
    }

}
/*enum PenalState
{
    IMVISIBOL,
    VISIBOL
}
class Penal
        {
            public GameObject Panel;
            public PenalState State { get; set; }

            public Penal(PenalState ws)
            {
                State = ws;

            }
            public void OpenPenal()
            {
                if (State == PenalState.IMVISIBOL)
                {
                    if (Panel == null)
                    {
                        bool noActive = Panel.activeSelf;
                        Panel.SetActive(noActive);
                    }
                    State = PenalState.VISIBOL;
                }
                else if (State == PenalState.VISIBOL)
                {
                    if (Panel != null)
                    {
                        bool isActive = Panel.activeSelf;
                        Panel.SetActive(isActive);
                    }
                    State = PenalState.IMVISIBOL;
                }
            }*/
    






