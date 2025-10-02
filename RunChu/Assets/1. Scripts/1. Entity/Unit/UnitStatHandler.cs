using UnityEngine;
using System;

/// <summary>
/// 인게임 내부에서 동적으로 변하는 Stat을 관리하는 클래스
/// </summary>
[Serializable]
public class UnitStat
{
    public int HP;
    public float Speed;
    public int TotalStamina;
    public int CurrentStamina;

    public void Init(UnitSO unitSO)
    {
        HP = unitSO.HP;
        Speed = unitSO.Speed;
        TotalStamina = unitSO.Stamina;
        CurrentStamina = 0;
    }
}

public class UnitStatHandler : MonoBehaviour
{
    [SerializeField] private UnitStat baseStat;
    [SerializeField] private UnitStat currentStat;

    private Unit unit;
    private bool isDie;

    public void Init(Unit unit)
    {
        this.unit = unit;

        baseStat = new UnitStat();
        currentStat = new UnitStat();

        baseStat.Init(unit.Data);
        currentStat.Init(unit.Data);

        isDie = false;
    }

    public float GetCurrentSpeed() => currentStat.Speed;
    public float GetJumpForce() => unit.Data.JumpForce;
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
        unit.EventHandler.CallHpChangeEvent(damage);
        Debug.Log($"Take {damage} Damage");

        if (currentStat.HP <= 0)
        {
            Debug.Log("Die");
            isDie = true;
            unit.EventHandler.CallDieEvent();
        }
    }

    public void IncreaseStamina(int staminaValue)
    {
        currentStat.CurrentStamina = Math.Min(currentStat.TotalStamina, currentStat.CurrentStamina + staminaValue);
        unit.EventHandler.CallStaminaChangeEvent(staminaValue);
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
