using System;
using UnityEngine;

public class UnitEventHandler : MonoBehaviour
{
    public event Action OnJump;
    public event Action<bool> OnSlide;
    public event Action<bool> OnGround;
    public event Action<int> OnHpChanged;
    public event Action<int> OnStaminaChanged;
    public event Action OnDie;

    public void CallJumpEvent()
    {
        OnJump?.Invoke();
    }

    public void CallSlideEvent(bool onSlide)
    {
        OnSlide?.Invoke(onSlide);
    }

    public void CallOnGroundEvent(bool onGround)
    {
        OnGround?.Invoke(onGround);
    }

    public void CallHpChangeEvent(int hpValue)
    {
        OnHpChanged?.Invoke(hpValue);
    }

    public void CallStaminaChangeEvent(int staminaValue)
    {
        OnStaminaChanged?.Invoke(staminaValue);
    }
    
    public void CallDieEvent()
    {
        OnDie?.Invoke();
    }

}
