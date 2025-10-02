using UnityEngine;

[CreateAssetMenu(menuName = "Entity/Player", fileName = "PlayerSO")]
public class PlayerSO : ScriptableObject
{
    [Header("Player Info")]
    [Range(10f, 50f)] public float Speed;
    [Range(5f, 20f)] public float JumpForce;

    [Header("Player Stat")]
    public int HP;
}
