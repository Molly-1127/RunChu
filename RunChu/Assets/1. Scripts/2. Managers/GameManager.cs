
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field:SerializeField] public Unit Unit { get; private set; }

    public void SetUnit(Unit unit)
    {
        Unit = unit;
    }
}
