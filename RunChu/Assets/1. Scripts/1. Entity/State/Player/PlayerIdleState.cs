public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(AnimParamHash.Idle);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(AnimParamHash.Idle);
    }
}