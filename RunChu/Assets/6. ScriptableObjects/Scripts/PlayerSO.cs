using UnityEngine;

[CreateAssetMenu(menuName = "Entity/Player", fileName = "PlayerSO")]
public class PlayerSO : ScriptableObject
{
    [Header("Player Info")]
    public int ID;
    public string Name;

    [Header("Player Stat")]
    public int HP;
    public int Stamina;
    [Range(10f, 50f)] public float Speed;
    [Range(5f, 20f)] public float JumpForce;
}
