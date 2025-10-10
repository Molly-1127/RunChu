using UnityEngine;
using System;
using System.Collections;

public class UnitStatHandler : MonoBehaviour
{
    [SerializeField] private UnitStat baseStat;
    [SerializeField] private UnitStat currentStat;

    private Unit unit;
    private bool isDie;
    private Coroutine slowCor;

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
    public bool IsDie() => isDie;

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

    #region TakeDamage 관련
    public void TakeDamage(int damage)
    {
        if (isDie) return;

        currentStat.HP = Math.Max(0, currentStat.HP - damage);
        unit.EventHandler.CallHpChangeEvent(damage);
        OnTakeDamage();
        Debug.Log($"Take {damage} Damage");

        if (currentStat.HP <= 0)
        {
            Debug.Log("Die");
            isDie = true;
            unit.EventHandler.CallDieEvent();
        }
    }

    public void OnTakeDamage()
    {
        GameManager.Instance.CameraEventHandler.CollideShake();

        if (slowCor != null)
            StopCoroutine(slowCor);
        slowCor = StartCoroutine(SlowCoroutine());
    }

    private IEnumerator SlowCoroutine()
    {
        float startTime = Time.time;
        float endTime = startTime + unit.Data.SlowDuration;
        Debug.Log($"startTime : {startTime} / endTime : {endTime}");

        currentStat.Speed = baseStat.Speed * unit.Data.SpeedReducer;

        while (Time.time < endTime)
        {
            unit.EffectHandler.SetSpriteTransparent();
            yield return Extension.ZeroPointOneWfs;
            unit.EffectHandler.SetSpriteOriginal();
            yield return Extension.ZeroPointOneWfs;
        }

        unit.EffectHandler.SetSpriteOriginal();
        currentStat.Speed = baseStat.Speed;
    }

    public void Boost()
    {
        currentStat.Speed = unit.Data.BoostSpeed;
    }

    public void Stop()
    {
        currentStat.Speed = 0f;
    }

    #endregion

}
