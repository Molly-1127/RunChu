using DG.Tweening;
using UnityEngine;

public class Obstacle_SingleJump : Obstacle
{
    [Header("Single Jump Obstacle Component")]
    [SerializeField] private float duration;
    [SerializeField] private Ease easeType;

    private Vector3 initPos;
    private readonly float yOffset = 3f;


    [ContextMenu("IntroAnim")]
    public override void IntroAnim()
    {
        base.IntroAnim();

        initPos = transform.position;
        transform.position = new Vector3(initPos.x, initPos.y - yOffset, initPos.z);
        transform.DOMove(initPos, duration).SetEase(easeType);
    }
}

