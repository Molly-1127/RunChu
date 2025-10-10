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