using UnityEngine;

public class PlayerSingleJumpState : PlayerBaseState
{
    public PlayerSingleJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
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