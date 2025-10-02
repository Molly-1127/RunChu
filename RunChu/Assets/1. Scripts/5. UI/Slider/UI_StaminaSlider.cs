using UnityEngine;
using DG.Tweening;

public class UI_StaminaSlider : UI_Slider
{
    [Header("Stamina Bar Component")]
    [SerializeField][Range(.1f, 3f)] private float slidingTime = 1.7f;

    private void Start()
    {
        slider.value = 0;
        GameManager.Instance.Player.EventHandler.OnStaminaChanged += UpdateStaminaBar;
    }

    private void UpdateStaminaBar(int staminaValue)
    {
        slider.DOKill(true); // 진행중인 트윈 중지

        DOTween.To(
            () => slider.value, // 현재 값
            x => slider.value = x,
            GameManager.Instance.Player.StatHandler.GetStaminaPercentage(), // 목표 값 = 1-현재 스태미나 퍼센테이지
            slidingTime)
            .SetEase(Ease.OutQuad); // duration
    }
}