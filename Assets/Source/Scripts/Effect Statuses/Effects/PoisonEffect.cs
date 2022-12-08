using UnityEngine;

public class PoisonEffect : EffectBase
{
    private float damage = 1;

    public PoisonEffect(IActionTarget target, float initDamage, int initDuration, Sprite sprite, bool tickOnEnd) : base(target, initDuration, sprite, tickOnEnd)
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