using DG.Tweening;
using UnityEngine;

public class Obstacle_DoubleJump : Obstacle
{
    [Header("Double Jump Obstacle Component")]
    [SerializeField] private float duration;
    [SerializeField] private Ease easeType;

    private Vector3 initPos;
    private readonly float yOffset = 5f;


    [ContextMenu("IntroAnim")]
    public override void IntroAnim()
    {
        base.IntroAnim();

        initPos = transform.position;
        transform.position = new Vector3(initPos.x, initPos.y - yOffset, initPos.z);
        transform.DOMove(initPos, duration).SetEase(easeType);
    }
}
