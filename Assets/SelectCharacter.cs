using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    public SelectCharacter[] chars;
    public Character character;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        if (DataManager.instance.currentCharacter == character) OnSelect();
        else OnDeSelect();
    }

    private void OnMouseUpAsButton()
    {
        DataManager.instance.currentCharacter = character;
        OnSelect();
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] != this) chars[i].OnDeSelect();
        }
    }

    void OnDeSelect()
    {
        anim.SetBool("Run", false);
        sr.color = new Color(0.5f, 0.5f, 0.5f);
    }

    void OnSelect()
    {
        anim.SetBool("Run", true);
        sr.color = new Color(1f, 1f, 1f);
    }
}
