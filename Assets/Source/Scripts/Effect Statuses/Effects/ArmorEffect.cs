using UnityEngine;
public class ArmorEffect : EffectBase
{
    private float health;
    public ArmorEffect(IActionTarget target, float health, int duration, Sprite sprite, bool tickOnEnd, Color color) : base(target, duration, sprite, tickOnEnd, color)
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