using System.Collections.Generic;
using UnityEngine;

public class PlayerTeam : TeamBase
{
    [SerializeField] private ActionHolder ActionHolderPrefab;

    private List<ActionHolder> actionHolders = new List<ActionHolder>();

    public override void StartTurn()
    {
        base.StartTurn();
        actionHolders.Clear();

        foreach (var character in characters)
        {
            var characterTransform = character.Key.transform;

            var actionHolder = Instantiate(ActionHolderPrefab, characterTransform.position + characterTransform.forward, characterTransform.rotation);
            actionHolder.Init(availableActions.GetRandom());

            actionHolders.Add(actionHolder);
        }
    }

    internal override void OnEndTurnMethod()
    {
        base.OnEndTurnMethod();

        foreach (var holder in actionHolders)
        {
            if (holder != null)
            {
                Destroy(holder.gameObject);
            }
        }
    }
}