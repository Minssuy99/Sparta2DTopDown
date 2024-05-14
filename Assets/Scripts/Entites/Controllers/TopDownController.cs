using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    // Action은 void형 메소드를 등록할 수 있는데 Vector2를 인자로 받는 메소드를 등록하도록 Action<Vector2>를 정의
    // event 키워드를 입력하면 public이더라도 나만 Invoke가능.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    // OnAttackEvent는 마우스 위치나 이동방향을 받지 않는 Action임
    public event Action<AttackSO> OnAttackEvent;

    private float timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }

    protected CharacterStatHandler stats { get; private set; }

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatHandler>();
    }

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack <= stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && timeSinceLastAttack > stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0;
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        // onMoveEvent는 public이어서 TopDownMovement에서 메소드들을 등록해놨음(a.k.a. 구독)
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        // 조준 시스템에서 등록했음.
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        // TopDownShooting에서 등록한 OnShoot 메소드가 구독되어 있음.
        OnAttackEvent?.Invoke(attackSO);
    }
}
