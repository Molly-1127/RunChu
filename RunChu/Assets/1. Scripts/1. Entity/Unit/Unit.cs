using UnityEngine;

public class Unit : Entity
{
    public UnitEventHandler EventHandler { get; private set; }
    public UnitMovementHandler MovementHandler { get; private set; }
    public UnitStatHandler StatHandler { get; private set; }
    public UnitEffectHandler EffectHandler { get; private set; }

    public UnitStateMachine StateMachine { get; private set; }


    [field: Header("Unit Data")]
    [field: SerializeField] public UnitSO UnitData { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.SetUnit(this);

        EventHandler = GetComponent<UnitEventHandler>();
        MovementHandler = GetComponent<UnitMovementHandler>();
        StatHandler = GetComponent<UnitStatHandler>();
        EffectHandler = GetComponent<UnitEffectHandler>();
    }

    void Start()
    {
        UnitInit();
        // TODO :: 스테이지 설계 이후 위치 수정
        StartRun();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
    }

    private void Update()
    {
        StateMachine.Update();
    }

    /// <summary>
    /// 플레이어 초기화 메서드 (서순주의)
    /// </summary>
    public void UnitInit()
    {
        StatHandler.Init(this);
        MovementHandler.Init(this);

        StateMachine = new UnitStateMachine(this);
        StateMachine.ChangeState(StateMachine.IdleState);

        StageManager.Instance.OnStageEnd += UnitDie;
    }

    private void UnitDie()
    {
        StatHandler.Stop();
        StatHandler.Die();
    }

    /// <summary>
    /// 스테이지 시작 또는 장애물 충돌 후 플레이어가 뛰기 시작할 때 실행되는 메서드
    /// </summary>
    public void StartRun()
    {
        StateMachine.ChangeState(StateMachine.RunState);
        MovementHandler.StartRun();
    }
}
