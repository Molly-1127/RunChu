using UnityEngine;
using DG.Tweening;
public class Obstacle_DropHazard : Obstacle
{
    [Header("DropHazard  Obstacle Component")]
    [SerializeField] private float duration;
    [SerializeField] private Ease easeType;
    [SerializeField] private float yOffset = 10f;
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

        initPos = transform.localPosition;
        transform.localPosition = new Vector3(initPos.x, initPos.y + yOffset, initPos.z);
        transform.DOLocalMove(initPos, duration).SetEase(easeType);
    }
}