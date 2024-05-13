using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject NpcTalkBox;
    public GameObject NpcTalkAcceptBox;

    private bool isAccept = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isAccept == false)
        {
            NpcTalkBox.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            NpcTalkBox.SetActive(false);
        }
    }

    public void NpcTalkAccept()
    {
        NpcTalkBox.SetActive(false);
        NpcTalkAcceptBox.SetActive(true);
        isAccept = true;
    }

    public void NpcTalkEnd()
    {
        NpcTalkAcceptBox.SetActive(false);
        isAccept = false;
    }
}
