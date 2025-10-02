using UnityEngine;
using System;

/// <summary>
/// 인게임 내부에서 동적으로 변하는 Stat을 관리하는 클래스
/// </summary>
[Serializable]
public class PlayerStat
{
    public int HP;
    public float Speed;
    public int TotalStamina;
    public int CurrentStamina;

    public void Init(PlayerSO playerSO)
    {
        HP = playerSO.HP;
        Speed = playerSO.Speed;
        TotalStamina = playerSO.Stamina;
        CurrentStamina = 0;
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
    public int GetMaxStamina() => currentStat.TotalStamina;
    public int GetCurrentStamina() => currentStat.CurrentStamina;
    public bool IsDie() => isDie;

    [ContextMenu("TakeRandomDamage")]
    public void TakeDamageRandom()
    {
        System.Random rand = new System.Random();
        TakeDamage(rand.Next(10, 50));
    }
    [ContextMenu("IncreaseRandomStamina")]
    public void IncreaseStaminaRandom()
    {
        System.Random rand = new System.Random();
        IncreaseStamina(rand.Next(50, 200));
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

    public void IncreaseStamina(int staminaValue)
    {
        currentStat.CurrentStamina = Math.Min(currentStat.TotalStamina, currentStat.CurrentStamina + staminaValue);
        player.EventHandler.CallStaminaChangeEvent(staminaValue);
    }

    public float GetHpPercentage()
    {
        return (float)currentStat.HP / baseStat.HP;
    }

    public float GetStaminaPercentage()
    {
        return (float)currentStat.CurrentStamina / currentStat.TotalStamina;
    }
}
