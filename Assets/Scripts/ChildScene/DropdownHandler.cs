using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{

    public GameObject Penal_result;//����� ����������
    public Text Text_result;// ����� ������ ���� (HE)
    public double result;// ��������� ��� �������
    public Text result3; //��� ������������
    public Text Text_gram;// ����� ������ ���� ��� ����� �������
    public Text Text_result_ed;//��������� ����� ���������� � ��������
    public double result2;//��������� � ��������
    public Dropdown dropdown;//���������� ����������� ������
    public int Uglivod;//�������� ���������
    public int gram_int;// ������ ��� �������

    public void DropdownItemSelected(Dropdown dropdown)
    {

        int index = dropdown.value;

        if (index == 0)
        {
            Uglivod = 20;
            Calculate_vizov();
        }

        if (index == 1)
        {
            Uglivod = 16;
            Calculate_vizov();
        }
        if (index == 2)
        {
            Uglivod = 18;
            Calculate_vizov();
        }

        if (index == 3)
        {
            Uglivod = 26;
            Calculate_vizov();
        }
        if (index == 4)
        {
            Uglivod = 22;
            Calculate_vizov();
        }
         

    }
  
    public void Calculate_vizov()//�����, ������������ � ������ Calculate
    {
        ButtonClick();
        gram_int = int.Parse(Text_gram.text);//��������� ��������� ������ � int
        result = (Uglivod * gram_int) / 1200 * 2;

        Text_result.text = result.ToString() + " ��";//������������ ���������� � ��������� ����

    }

    public void ButtonClick()
    {
        if (Text_gram.text == "")
        {
            Debug.Log("������� ����������� �������");
        }
        else
        {
            gram_int = int.Parse(Text_gram.text);
            result = (Uglivod * gram_int) / 1200;
            Text_result.text = result.ToString() + " HE";
            if (Penal_result != null)
            {
                bool isActive = Penal_result.activeSelf;
                Penal_result.SetActive(!isActive);
            }

        }
    }
}
       


