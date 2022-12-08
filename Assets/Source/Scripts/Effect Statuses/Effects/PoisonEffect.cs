using UnityEngine;

public class PoisonEffect : EffectBase
{
    private float damage = 1;

    public PoisonEffect(IActionTarget target, float initDamage, int initDuration, Sprite sprite) : base(target, initDuration, sprite)
    {
        damage = initDamage;
    }

    public override void OnEffectCancel()
    {
        
    }

    public override void OnEffectStart()
    {
        
    }

    public override void TickEffect()
    {
        target.ApplyDamage(damage);
    }
}