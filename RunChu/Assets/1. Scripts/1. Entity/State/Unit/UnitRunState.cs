using UnityEngine;

public class UnitRunState : UnitBaseState
{
    public UnitRunState(UnitStateMachine unitStateMachine) : base(unitStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(AnimParamHash.Run);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(AnimParamHash.Run);
    }
}