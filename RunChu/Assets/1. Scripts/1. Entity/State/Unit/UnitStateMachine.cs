public class UnitStateMachine : EntityStateMachine
{
    public UnitIdleState IdleState;
    public UnitRunState RunState;
    public UnitSingleJumpState SingleJumpState;
    public UnitDoubleJumpState DoubleJumpState;
    public UnitSlideState SlideState;

    public UnitStateMachine(Unit player)
    {
        Entity = player;

        IdleState = new UnitIdleState(this);
        RunState = new UnitRunState(this);
        SingleJumpState = new UnitSingleJumpState(this);
        DoubleJumpState = new UnitDoubleJumpState(this);
        SlideState = new UnitSlideState(this);
    }
}
