using UnityEngine;

public class PoisonEffect : EffectBase
{
    private float damage = 1;

    public PoisonEffect(IActionTarget target, float initDamage, int initDuration, Sprite sprite, bool tickOnEnd, Color color) : base(target, initDuration, sprite, tickOnEnd, color)
    {
        damage = initDamage;
    }

    public override void OnEffectCancel()
    {
        
    }

    public override void OnEffectStart()
    {
        target.ApplyDamage(damage);
    }

    public override void TickEffect()
    {
        target.ApplyDamage(damage);
    }
}