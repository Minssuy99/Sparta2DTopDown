using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public GameObject player;

    void Start()
    {
        player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
        player.tag = "Player"; // 태그 설정
        player.transform.position = transform.position;
    }

}
