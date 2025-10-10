
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public CameraEventHandler CameraEventHandler;

    [field: SerializeField] public Unit Unit { get; private set; }

    public void SetUnit(Unit unit)
    {
        Unit = unit;
    }
}
