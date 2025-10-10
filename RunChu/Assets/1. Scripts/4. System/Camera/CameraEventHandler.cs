using System.Collections;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// 카메라 연출(Shake) 관련 클래스
/// </summary>
public class CameraEventHandler : MonoBehaviour
{
    [Header("Camera Shake Component")]
    [Header("Collide Component")]
    [SerializeField] private float collideShakeDuration;
    [SerializeField] private Vector3 collideShakeMagnitude;
    [SerializeField] private int collideVibrato;
    [SerializeField] private Ease collideEaseType;

    [Header("Boost Component")]
    [SerializeField] private float boostShakeDuration;
    [SerializeField] private Vector3 boostShakeMagnitude;
     [SerializeField] private int boostVibrato;
    [SerializeField] private Ease boostEaseType;

    private void Awake()
    {
        GameManager.Instance.CameraEventHandler = this;
    }

    [ContextMenu("Collide")]
    public void CollideShake()
    {
        OnCollideCameraShake();
    }
    
    [ContextMenu("Boost")]
    public void BoostShake()
    {
        OnBoostCameraShake();
    }

    public void OnCollideCameraShake()
    {
        ShakeCamera(collideShakeDuration, collideShakeMagnitude,collideVibrato,collideEaseType);
    }

    public void OnBoostCameraShake()
    {
        ShakeCamera(boostShakeDuration, boostShakeMagnitude,boostVibrato,boostEaseType);
    }

    /// <summary>
    /// 카메라 흔드는 연출 메서드
    /// </summary>
    /// <param name="duration">shake 지속시간</param>
    /// <param name="magnitude">shake 강도</param>
    private void ShakeCamera(float duration, Vector3 magnitude, int vibrato, Ease easeType)
    {
        transform.DOShakePosition(duration, magnitude, vibrato).SetEase(easeType);
    }
}
