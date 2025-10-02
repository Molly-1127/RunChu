using UnityEngine;

public class UnitBaseState : EntityBaseState
{
    protected UnitStateMachine stateMachine;
    protected Unit unit;

    public UnitBaseState(UnitStateMachine unitStateMachine) : base(unitStateMachine)
    {
        stateMachine = unitStateMachine;
        unit = unitStateMachine.Entity as Unit;
    }

}