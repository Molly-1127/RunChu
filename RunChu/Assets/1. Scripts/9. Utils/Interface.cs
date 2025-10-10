public interface IState
{
    public void Enter();
    public void Exit();
    public void Update();
    public void FixedUpdate();
}

public interface IObstacle
{
    public void Init();
    public void OnCollide();
    public void IntroAnim();
}