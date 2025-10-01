public class EntityBaseState : IState
{
    private Entity entity;

    public EntityBaseState(EntityStateMachine stateMachine)
    {
        entity = stateMachine.Entity;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void Update()
    {

    }

    public void StartAnimation(int animHash)
    {
        entity.Animator.SetBool(animHash, true);
    }

    public void StopAnimation(int animHash)
    {
        entity.Animator.SetBool(animHash, false);
    }
}