using UnityEngine;

public class PlayerDoubleJumpState : PlayerBaseState
{
    public PlayerDoubleJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
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