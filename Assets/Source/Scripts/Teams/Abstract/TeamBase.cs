using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class TeamBase : MonoBehaviour
{
    [SerializeField] private TeamSide teamSide = TeamSide.Enemy;
    internal ActionBase[] availableActions;
    internal Dictionary<CharacterBase, StatusHandler> characters = new Dictionary<CharacterBase, StatusHandler>();

    public Action OnEndTurn;
    public Action<TeamSide> OnLose;

    public virtual void Init(ActionBase[] availableActions)
    {
        this.availableActions = availableActions;

        var charactersBases = GetComponentsInChildren<CharacterBase>();

        foreach (var character in charactersBases)
        {
            character.SetTeamSide(teamSide);

            characters.Add(character, character.GetComponent<StatusHandler>());

            character.OnDie += OnCharacterDie;
        }
    }
    public virtual void StartTurn()
    {
        foreach (var handler in characters.Values)
        {
            handler.TickAllEffects();
        }
    }
    private void OnCharacterDie(CharacterBase character)
    {
        characters.Remove(character);

        if (characters.Count == 0)
        {
            OnLose?.Invoke(teamSide);
        }
    }
}