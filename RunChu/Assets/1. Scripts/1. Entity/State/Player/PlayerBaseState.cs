using UnityEngine;

public class PlayerBaseState : EntityBaseState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    public PlayerBaseState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        stateMachine = playerStateMachine;
        player = playerStateMachine.Entity as Player;
    }

    // public override void Update()
    // {
    //     base.Update();
    //     // TODO :: Player 죽었을 때 Stop 처리
    // }

}