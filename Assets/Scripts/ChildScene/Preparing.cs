using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Preparing : MonoBehaviour
{
    public int gram_int;// ������ ��� �������
    //DropdownHandler uglivod = new DropdownItemSelected();
    //public DropdownHandler uglivod;
    public int uglivod;//�������� � ������������ ���������

    public GameObject Penal_result;//����� ����������
    public Text Text_result;// ����� ������ ���� (HE)
    public double result;// ��������� ��� �������
    public Text result3; //��� ������������
    public Text Text_gram;// ����� ������ ���� ��� ����� �������
    public Text Text_result_ed;//��������� ����� ���������� � ��������
    public double result2;//��������� � ��������

    public void Calculate_HE()
    {

        if (Text_gram.text == "")
        {
            Debug.Log("������� ����������� �������");
        }
        else
        {
            if (Penal_result != null)
            {
                bool isActive = Penal_result.activeSelf;
                Penal_result.SetActive(!isActive);
            }

        }
        
        
            gram_int = int.Parse(Text_gram.text);

            
            result2 = Calculate_He.Calculate(uglivod, gram_int) * 2;//2-KUI �������� �� ��
            Text_result.text = result2.ToString() + " ��";
            Text_result_ed.text = Calculate_He.Calculate(uglivod, gram_int).ToString() + " ��";
            result3.text = gram_int.ToString() + " " + uglivod.ToString();
        
    }
}
 
    
    
 

    

