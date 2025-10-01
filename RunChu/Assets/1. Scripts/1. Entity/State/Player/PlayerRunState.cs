using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
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