using UnityEngine;

[CreateAssetMenu(menuName = "Entity/Player", fileName = "PlayerSO")]
public class PlayerSO : ScriptableObject
{
    [Header("Player Info")]
    [Range(1f, 10f)] public float Speed;
    [Range(5f, 20f)] public float JumpForce;

    [Header("Player Stat")]
    public float Health;
    public float Defense;
    public float Evasion;
}
