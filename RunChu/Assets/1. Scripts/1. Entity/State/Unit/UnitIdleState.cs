public class UnitIdleState : UnitBaseState
{
    public UnitIdleState(UnitStateMachine unitStateMachine) : base(unitStateMachine)
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