using DG.Tweening;
using UnityEngine;

public class Obstacle_Jump : Obstacle
{
    [Header("Jump Obstacle Component")]
    [SerializeField] private float duration;
    [SerializeField] private Ease easeType;
    [SerializeField] private float yOffset = 3f;

    private Vector3 initPos;

    public override void OnCollide()
    {
        base.OnCollide();
        GameManager.Instance.Unit.StatHandler.TakeDamage(damage);
    }

    [ContextMenu("IntroAnim")]
    public override void IntroAnim()
    {
        base.IntroAnim();

        // 장애물이 배경의 하위 오브젝트가 되어 움직일 것이기 때문에, local Position 기준으로 이동시켜야함.
        initPos = transform.localPosition;
        transform.localPosition  = new Vector3(initPos.x, initPos.y - yOffset, initPos.z);
        transform.DOLocalMove(initPos, duration).SetEase(easeType);
    }
}

