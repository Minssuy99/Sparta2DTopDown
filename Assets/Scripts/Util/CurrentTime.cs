using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;

public class CurrentTime : MonoBehaviour
{
    DateTime currentTime = DateTime.Now;
    public TMP_Text TimeTxt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeTxt.text = ($"{currentTime.Hour} : {currentTime.Minute}");
    }
}
