using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeam : TeamBase
{
    [SerializeField] private float enemyAttackTime = 2f;
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
            yield return new WaitForSeconds(enemyAttackTime);

            if (possibleTargets.Count == 0)
            {
                continue;
            }

            var action = availableActions.GetRandom();

            if (action.forEnemies)
            {
                action.DoAction(possibleTargets.GetRandom().Key);
            }
            else
            {
                action.DoAction(characters.GetRandom().Key);
            }
        }

        yield return new WaitForSeconds(1f);
        
        OnEndTurn?.Invoke();
    }
}