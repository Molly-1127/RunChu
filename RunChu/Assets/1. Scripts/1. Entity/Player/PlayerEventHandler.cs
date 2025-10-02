using System;
using UnityEngine;

public class PlayerEventHandler : MonoBehaviour
{
    public event Action OnJump;
    public event Action<bool> OnSlide;
    public event Action<bool> OnGround;
    public event Action<float> OnHpChanged; // HpBar
    public event Action<float> OnStaminaChanged;
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

    public void CallHpChangeEvent(int damageValue)
    {
        OnHpChanged?.Invoke(damageValue);
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
