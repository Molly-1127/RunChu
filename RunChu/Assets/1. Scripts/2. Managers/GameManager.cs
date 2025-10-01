using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field:SerializeField] public Player Player { get; private set; }

    public void SetPlayer(Player player)
    {
        Player = player;
    }
}
