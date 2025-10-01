using System;
using UnityEngine;

public class PlayerEventHandler : MonoBehaviour
{
    public event Action OnJump;
    public event Action<bool> OnSlide;
    public event Action<bool> OnGround;

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
}
