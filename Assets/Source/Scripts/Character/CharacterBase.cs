using System;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IActionTarget
{
    [SerializeField] private float maxHealth;

    internal float health;
    internal float additionalHealth;
    internal StatusHandler statusHandler;
    internal TeamSide teamSide;

    public TeamSide GetTeamSide() => teamSide;
    public TeamSide SetTeamSide(TeamSide teamSide) => this.teamSide = teamSide;

    public event Action<CharacterBase> OnDie;

    private void Awake()
    {
        health = maxHealth;
        additionalHealth = 0;
        statusHandler = GetComponent<StatusHandler>();
    }

    public void ClearEffect(EffectBase effect)
    {
        statusHandler.ClearEffect(effect);
    }
    public void ApplyEffect(EffectBase effect)
    {
        statusHandler.AddEffect(effect);
    }

    public void ApplyDamage(float damage)
    {
        var damageCounter = damage;

        if (damageCounter <= additionalHealth)
        {
            additionalHealth -= damageCounter;
            return;
        }

        additionalHealth = 0;
        damageCounter -= additionalHealth;

        health -= damageCounter;

        if (health <= 0)
        {
            Die();
        }

        Debug.Log(health);
    }

    private void Die()
    {
        OnDie?.Invoke(this);
    }

    public void ApplyHeal(float heal)
    {
        health = Mathf.Clamp(health + heal, 0, maxHealth);
    }

    public void ApplyAdditionalHeal(float heal)
    {
        additionalHealth = heal;
    }

    public void ClearAdditionalHeal()
    {
        additionalHealth = 0;
    }
    public float GetHealth()
    {
        return health;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
}