public class EntityStateMachine
{
    public Entity Entity;
    public IState CurrentState;

    public void ChangeState(IState state)
    {
        CurrentState?.Exit();
        CurrentState = state;
        CurrentState?.Enter();
    }

    public void Update()
    {
        CurrentState?.Update();    
    }

    public void FixedUpdate()
    {
        CurrentState?.FixedUpdate();
    }
}
