using UnityEngine;

public class UnitDoubleJumpState : UnitBaseState
{
    public UnitDoubleJumpState(UnitStateMachine unitStateMachine) : base(unitStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(AnimParamHash.DoubleJump);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(AnimParamHash.DoubleJump);
    }
}