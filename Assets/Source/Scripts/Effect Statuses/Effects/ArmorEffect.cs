using UnityEngine;
public class ArmorEffect : EffectBase
{
    private float health;
    public ArmorEffect(IActionTarget target, float health, int duration, Sprite sprite, bool tickOnEnd) : base(target, duration, sprite, tickOnEnd)
    {
        this.health = health;
    }

    public override void OnEffectCancel()
    {
        target.ClearAdditionalHeal();
    }

    public override void OnEffectStart()
    {
        target.ApplyAdditionalHeal(health);
    }

    public override void TickEffect()
    {
        
    }
}