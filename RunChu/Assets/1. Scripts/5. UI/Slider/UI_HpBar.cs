
using DG.Tweening;
using UnityEngine;

public class UI_HpBar : UI_Slider
{
    [Header("HP Bar Component")]
    [SerializeField] [Range(.1f,3f)] private float slidingTime;
 
    private void Start()
    {
        GameManager.Instance.Player.EventHandler.OnHpChanged += UpdateHpBar;
    }

    private void UpdateHpBar(float hpValue)
    {
        slider.DOKill(true); // 진행중인 트윈 중지

        DOTween.To(
            () => slider.value, // 현재 값
            x => slider.value = x,
            GameManager.Instance.Player.StatHandler.GetHpPercentage(), // 목표 값
            slidingTime)
            .SetEase(Ease.OutQuad); // duration
    }
}