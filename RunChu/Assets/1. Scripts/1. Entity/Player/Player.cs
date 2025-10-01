using UnityEngine;

public class Player : Entity
{
    public PlayerEventHandler EventHandler { get; private set; }
    public PlayerMovementHandler MovementHandler { get; private set; }
    public PlayerStatHandler StatHandler{ get; private set; }

    public PlayerStateMachine StateMachine { get; private set; }


    [field:Header("Player Data")]
    [field:SerializeField] public PlayerSO Data{ get; private set; }

    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.SetPlayer(this);

        EventHandler = GetComponent<PlayerEventHandler>();
        MovementHandler = GetComponent<PlayerMovementHandler>();
        StatHandler = GetComponent<PlayerStatHandler>();
    }

    void Start()
    {
        PlayerInit();
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
    public void PlayerInit()
    {
        StatHandler.Init(this);
        MovementHandler.Init(this); 

        StateMachine = new PlayerStateMachine(this);
        StateMachine.ChangeState(StateMachine.IdleState); 
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
