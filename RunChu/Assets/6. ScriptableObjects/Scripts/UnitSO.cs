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
    [Range(10f, 50f)] public float Speed; // 기본 이속
    [Range(1f, 5f)] public float SpeedMultiplier; // 부스트 or 녹은 장판에서 얼마나 속도가 변할지
    [Range(15f, 20f)] public float JumpForce; // 점프 Force
}
