using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform Player { get; private set; }
    public ObjectPool ObjectPool { get; private set; }
    [SerializeField] private string playerTag = "Player";

    // 플레이어를 찾은 후에 발생시킬 이벤트
    public event Action PlayerFound;

    private void Awake()
    {
        Instance = this;
        StartCoroutine(FindPlayerWithTag());
    }

    private System.Collections.IEnumerator FindPlayerWithTag()
    {
        yield return new WaitUntil(() => GameObject.FindGameObjectWithTag(playerTag) != null);

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
        ObjectPool = GetComponent<ObjectPool>();

        // 플레이어를 찾은 후에 이벤트 발생
        PlayerFound?.Invoke();
    }
}
