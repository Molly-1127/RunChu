
public class PlayerSlideState: PlayerBaseState
{
    public PlayerSlideState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(AnimParamHash.Slide);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(AnimParamHash.Slide);
    }
}