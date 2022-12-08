using System;
using System.Collections.Generic;
using UnityEngine;

public class StatusHandler : MonoBehaviour
{
    private Dictionary<EffectBase, int> effects = new Dictionary<EffectBase, int>();
    public Dictionary<EffectBase, int> GetEffects() => effects;

    public event Action OnEffectUpdate;

    public void AddEffect(EffectBase effect)
    {
        foreach (var item in effects.Keys)
        {
            if (item.GetType() == effect.GetType())
            {
                effects[item] = effect.GetEffectTurns();
                item.OnEffectStart();
                OnEffectUpdate?.Invoke();

                return;
            }
        }
        effects.Add(effect, effect.GetEffectTurns());

        Debug.Log($"Adding to {gameObject.name} {effect.GetType().Name}");

        effect.OnEffectStart();
        OnEffectUpdate?.Invoke();
    }
    public void ClearEffect(EffectBase effect)
    {
        Dictionary<EffectBase, int> newDictionary = new Dictionary<EffectBase, int>(effects);

        foreach (var item in newDictionary.Keys)
        {
            if (item.GetType() == effect.GetType())
            {
                item.OnEffectCancel();
                effects.Remove(item);
            }
        }

        OnEffectUpdate?.Invoke();
    }
    public void TickAllEffectsOnStart()
    {
        Dictionary<EffectBase, int> newDictionary = new Dictionary<EffectBase, int>(effects);

        foreach (var item in effects)
        {
            Debug.Log($"{item.Key.GetType().Name} {item.Value}");
        }

        foreach (var effect in newDictionary.Keys)
        {
            if (effect.tickOnEnd)
            {
                continue;
            }

            effect.TickEffect();
            effects[effect]--;

            if (effects[effect] <= 0)
            {
                effect.OnEffectEnd();
            }
        }
    }
    public void TickAllEffectsOnEnd()
    {
        Dictionary<EffectBase, int> newDictionary = new Dictionary<EffectBase, int>(effects);

        foreach (var item in effects)
        {
            Debug.Log($"{item.Key.GetType().Name} {item.Value}");
        }

        foreach (var effect in newDictionary.Keys)
        {
            if (!effect.tickOnEnd)
            {
                continue;
            }

            effect.TickEffect();
            effects[effect]--;

            if (effects[effect] <= 0)
            {
                effect.OnEffectEnd();
            }
        }
    }
}