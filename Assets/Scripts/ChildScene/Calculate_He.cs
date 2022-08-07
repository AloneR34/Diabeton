using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Calculate_He : MonoBehaviour
{
    public int gram_int;
    public int uglivod;
    public static double Calculate(int uglivod, int gram_int)
    {
        var result = 0;
        if (gram_int != 0)
            result = (uglivod * gram_int) / 1200;
        return result;
    }
}