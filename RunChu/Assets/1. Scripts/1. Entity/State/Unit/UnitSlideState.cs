
public class UnitSlideState: UnitBaseState
{
    public UnitSlideState(UnitStateMachine unitStateMachine) : base(unitStateMachine)
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