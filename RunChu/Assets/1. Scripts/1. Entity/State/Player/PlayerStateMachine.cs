public class PlayerStateMachine : EntityStateMachine
{
    public PlayerIdleState IdleState;
    public PlayerRunState RunState;
    public PlayerSingleJumpState SingleJumpState;
    public PlayerDoubleJumpState DoubleJumpState;
    public PlayerSlideState SlideState;

    public PlayerStateMachine(Player player)
    {
        Entity = player;

        IdleState = new PlayerIdleState(this);
        RunState = new PlayerRunState(this);
        SingleJumpState = new PlayerSingleJumpState(this);
        DoubleJumpState = new PlayerDoubleJumpState(this);
        SlideState = new PlayerSlideState(this);
    }
}
