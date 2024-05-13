using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Unity.VisualScripting;


public class PlayerInfo : MonoBehaviour
{
    private string playerNameKey;
    private string playerName;
    public TMP_InputField NickName;
    public TMP_Text PlayerNameTxt;

    public GameObject ChangeNameTable;

    private void Start()
    {
        if (PlayerNameTxt == true)
        {
            string currentName = PlayerPrefs.GetString("playerName");
            PlayerNameTxt.text = currentName;
        }

    }
    private void NameSelect()
    {

        string enterName = NickName.text;
        playerNameKey = "playerName";

        PlayerPrefs.SetString(playerNameKey, enterName);
        playerName = enterName;


    }
    public void GameStart()
    {
        NameSelect();
        int nameLength = NickName.text.Length;

        if (nameLength >= 2 && nameLength <= 10)
        {
            SceneManager.LoadScene("SampleScene");
        }
        Debug.Log(playerName);
    }

    public void TryChangeName()
    {
        ChangeNameTable.SetActive(true);
    }

    public void ChangeNameEnd()
    {
        NameSelect();
        int nameLength = NickName.text.Length;
        if (nameLength >= 2 && nameLength <= 10)
        {
            ChangeNameTable.SetActive(false);
            string currentName = PlayerPrefs.GetString("playerName");
            PlayerNameTxt.text = currentName;
        }
    }

    // public void ChangeName()
    // {

    // }
}
