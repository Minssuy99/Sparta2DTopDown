using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NicknameDisplay : MonoBehaviour
{
    public Text playerNameText;
    void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        playerNameText.text = playerName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
