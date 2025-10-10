using UnityEngine;

[CreateAssetMenu(menuName = "Entity/Unit", fileName = "UnitSO")]
public class UnitSO : ScriptableObject
{
    [Header("Unit Info")]
    public int ID; // id
    public string Name; // 캐릭터 명

    [Header("Unit Stat")]
    public int HP; // 체력 총량
    public int Stamina; // 스태미나 총량
    [Range(10f, 20f)] public float Speed; // 기본 이속
    [Range(20f, 50f)] public float BoostSpeed; // 부스트 속도
    [Range(0f, 1f)] public float SpeedReducer; // 충돌 or 피격 시 속도 감속
    [Range(1f, 15f)] public float SlowDuration; // 충돌 발생 시 감속 지속시간
    [Range(15f, 20f)] public float JumpForce; // 점프 Force
}
