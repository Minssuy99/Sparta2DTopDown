using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Time_Test : MonoBehaviour
{
    public Text TimeTxT;

    void Update()
    {
        GetCurrentDate();
    }
    public void GetCurrentDate()
    {
        string DayTime = DateTime.Now.ToString(("HH:mm"));
        TimeTxT.text = DayTime;
    }

}