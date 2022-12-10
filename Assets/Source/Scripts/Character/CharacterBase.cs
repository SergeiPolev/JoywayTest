using System;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IActionTarget
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject dieVFX;
    [SerializeField] private GameObject highlight;

    internal float health;
    internal float additionalHealth;
    internal StatusHandler statusHandler;
    internal TeamSide teamSide;

    public TeamSide GetTeamSide() => teamSide;
    public float GetAdditionalHealth() => additionalHealth;
    public float GetHealth() => health;
    public float GetMaxHealth() => maxHealth;
    public void TurnHighlight(bool enabled) => highlight?.SetActive(enabled);

    public TeamSide SetTeamSide(TeamSide teamSide) => this.teamSide = teamSide;

    public event Action OnHealthChange;
    public event Action<CharacterBase> OnDie;

    private void Awake()
    {
        health = maxHealth;
        additionalHealth = 0;
        statusHandler = GetComponent<StatusHandler>();

        if (statusHandler == null)
        {
            Debug.LogError($"NO STATUS HANDLER ON {gameObject.name}");
        }
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

        PopupDamageTextHandler._instance.SpawnPopup(transform.position, damage);

        if (damageCounter <= additionalHealth)
        {
            additionalHealth -= damageCounter;

            RemoveAdditionalHealth();

            return;
        }

        damageCounter -= additionalHealth;

        additionalHealth = 0;
        RemoveAdditionalHealth();

        health = Mathf.Clamp(health - damageCounter, 0, maxHealth);

        HealthChanged();

        if (health <= 0)
        {
            Die();
        }

        Debug.Log(health);
    }

    private void RemoveAdditionalHealth()
    {
        if (additionalHealth <= 0)
        {
            ClearEffect(new ArmorEffect(null, 0, 0, null, false, Color.white));
        }
    }

    private void Die()
    {
        VisualEffectsExtension.SpawnSingleVFX(dieVFX, transform.position, 2f);

        OnDie?.Invoke(this);
    }

    public void ApplyHeal(float heal)
    {
        health = Mathf.Clamp(health + heal, 0, maxHealth);

        PopupDamageTextHandler._instance.SpawnPopup(transform.position, -heal);

        HealthChanged();
    }

    public void ApplyAdditionalHeal(float heal)
    {
        additionalHealth = heal;

        PopupDamageTextHandler._instance.SpawnPopup(transform.position, -heal);

        HealthChanged();
    }

    public void ClearAdditionalHeal()
    {
        additionalHealth = 0;

        HealthChanged();
    }

    private void HealthChanged()
    {
        OnHealthChange?.Invoke();
    }
}