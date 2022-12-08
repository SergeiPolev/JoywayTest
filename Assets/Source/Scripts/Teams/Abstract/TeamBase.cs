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

    public Dictionary<CharacterBase, StatusHandler> GetCharacters() => characters;

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

        OnEndTurn += OnEndTurnMethod;
    }
    public virtual void StartTurn()
    {
        List<StatusHandler> tempList = new List<StatusHandler>(characters.Values);

        foreach (var handler in tempList)
        {
            handler.TickAllEffectsOnStart();
        }
    }
    internal virtual void OnEndTurnMethod()
    {
        List<StatusHandler> tempList = new List<StatusHandler>(characters.Values);

        foreach (var handler in tempList)
        {
            handler.TickAllEffectsOnEnd();
        }
    }
    private void OnCharacterDie(CharacterBase character)
    {
        characters.Remove(character);
        Destroy(character.gameObject);

        if (characters.Count == 0)
        {
            OnLose?.Invoke(teamSide);
        }
    }
}