using UnityEngine;

public static class AnimParamHash
{
    public static readonly int Idle = Animator.StringToHash("Idle");
    public static readonly int Run = Animator.StringToHash("Run");
    public static readonly int SingleJump = Animator.StringToHash("SingleJump");
    public static readonly int DoubleJump = Animator.StringToHash("DoubleJump");
    public static readonly int Slide = Animator.StringToHash("Slide");
    public static readonly int Die = Animator.StringToHash("Die");
}