using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeam : TeamBase
{
    private Dictionary<CharacterBase, StatusHandler> possibleTargets;

    private Coroutine teamTurns;
    public void Init(ActionBase[] availableActions, Dictionary<CharacterBase, StatusHandler> playerTargets)
    {
        base.Init(availableActions);

        possibleTargets = playerTargets;
    }
    public override void StartTurn()
    {
        base.StartTurn();

        if (possibleTargets == null || possibleTargets.Count == 0)
        {
            Debug.LogError("No Possible Targets");

            return;
        }

        teamTurns = StartCoroutine(DoActions());
    }

    private IEnumerator DoActions()
    {
        foreach (var character in characters)
        {
            if (possibleTargets.Count == 0)
            {
                continue;
            }

            availableActions.GetRandom().DoAction(possibleTargets.GetRandom().Key);

            yield return new WaitForSeconds(1f);
        }

        OnEndTurn?.Invoke();
    }
}