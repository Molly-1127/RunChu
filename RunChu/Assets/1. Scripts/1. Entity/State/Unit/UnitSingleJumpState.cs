using UnityEngine;

public class UnitSingleJumpState : UnitBaseState
{
    public UnitSingleJumpState(UnitStateMachine unitStateMachine) : base(unitStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(AnimParamHash.SingleJump);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(AnimParamHash.SingleJump);
    }
}