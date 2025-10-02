using UnityEngine;
using System;

/// <summary>
/// 인게임 내부에서 동적으로 변하는 Stat을 관리하는 클래스
/// </summary>
[Serializable]
public class PlayerStat
{
    public int HP;
    public int Stamina;
    public float Speed;

    public void Init(PlayerSO playerSO)
    {
        HP = playerSO.HP;
        Speed = playerSO.Speed;
        Stamina = 0;
    }
}

public class PlayerStatHandler : MonoBehaviour
{
    [SerializeField] private PlayerStat baseStat;
    [SerializeField] private PlayerStat currentStat;

    private Player player;
    private bool isDie;

    public void Init(Player player)
    {
        this.player = player;

        baseStat = new PlayerStat();
        currentStat = new PlayerStat();

        baseStat.Init(player.Data);
        currentStat.Init(player.Data);

        isDie = false;
    }

    public float GetCurrentSpeed() => currentStat.Speed;
    public float GetJumpForce() => player.Data.JumpForce;
    public int GetMaxHp() => baseStat.HP;
    public int GetCurrentHp() => currentStat.HP;
    public int GetMaxStamina() => baseStat.Stamina;
    public int GetCurrentStamina() => currentStat.Stamina;
    public bool IsDie() => isDie;

    [ContextMenu("TakeDamage10")]
    public void TakeDamage10()
    {
        TakeDamage(10);
    }

    public void TakeDamage(int damage)
    {
        if (isDie) return;

        currentStat.HP = Math.Max(0, currentStat.HP - damage);
        player.EventHandler.CallHpChangeEvent(damage);

        if (currentStat.HP <= 0)
        {
            Debug.Log("PlayerDie");
            isDie = true;
            player.EventHandler.CallDieEvent();
        }
    }

    public float GetHpPercentage()
    {
        return (float)currentStat.HP / baseStat.HP;
    }

    public float GetStaminaPercentage()
    {
        return currentStat.Stamina / baseStat.Stamina;
    }
}
