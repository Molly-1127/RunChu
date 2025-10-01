using UnityEngine;

/// <summary>
/// 인게임 내부에서 동적으로 변하는 Stat을 관리하는 Handler
/// </summary>
public class PlayerStatHandler : MonoBehaviour
{
    private Player player;

    public void Init(Player player)
    {
        this.player = player;
    }

    public float GetSpeed() => player.Data.Speed;
    public float GetJumpForce() => player.Data.JumpForce;
}
