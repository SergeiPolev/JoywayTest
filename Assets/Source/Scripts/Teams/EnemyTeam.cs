using UnityEngine;

public class EnemyTeam : TeamBase
{
    public override void Init(ActionBase[] availableActions)
    {
        base.Init(availableActions);

    }
    public override void StartTurn()
    {
        base.StartTurn();

        OnEndTurn?.Invoke();
    }
}